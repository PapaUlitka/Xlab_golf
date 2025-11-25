using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class GameplayState : StateBase
    {

        [SerializeField] private Stick m_stick;
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private ScoreManager m_scoreManager;
        [SerializeField] private PlayerController m_playerController;
        [SerializeField] private LevelController m_levelController;
        [SerializeField] private GameObject m_gameplayPanel;
        [SerializeField] private Button m_upgradeButton;
        [SerializeField] private GameObject m_upgradePanel;
        [SerializeField] private Button m_firstUpgrade;
        [SerializeField] private Button m_secondUpgrade;
        [SerializeField] private Button m_backButton;
        [SerializeField] private Button m_achButton;
        [SerializeField] private GameObject m_achPanel;
        [SerializeField] private Button m_achBackButton;

        private GameStateMachine m_gamestateMachine;
        public override void Initialize(GameStateMachine gameStateMachine)
        {
            m_upgradePanel.SetActive(false);
            m_gameplayPanel.SetActive(false);
            m_gamestateMachine = gameStateMachine;
        }
        public override void Enter()
        {
            m_scoreManager.Reset();
            m_scoreManager.ScoreChanged += OnScoreChanged;
            OnScoreChanged(m_scoreManager.score);
            m_gameplayPanel.SetActive(true);

            m_achButton.onClick.AddListener(ShowAchivements);
            m_upgradeButton.onClick.AddListener(ShowUpgradePanel);
            m_firstUpgrade.onClick.AddListener(OnFirstUpgrade);
            m_secondUpgrade.onClick.AddListener(OnSecondUpgrade);
            m_backButton.onClick.AddListener(OnClose);
            m_achBackButton.onClick.AddListener(OnAchBack);

            m_levelController.enabled = true;
            m_playerController.enabled = true;
            m_levelController.Initialize();
            m_levelController.Finished += OnFinished;
        }

        private void OnAchBack()
        {
            m_achPanel.SetActive(false);
        }

        private void ShowAchivements()
        {
            m_achPanel.SetActive(true);
        }

        private void OnClose()
        {
            m_upgradePanel?.SetActive(false);
        }

        private void OnSecondUpgrade()
        {
            if (m_scoreManager.score >= 2)
            {
                m_stick.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                m_scoreManager.score -= 2;
            }

        }
        private void OnFirstUpgrade()
        {
            if (m_scoreManager.score >= 1)
            {
                m_stick.power += 100;
                m_scoreManager.score -= 1;
            }
        }

        private void ShowUpgradePanel()
        {
            m_upgradePanel.SetActive(true);
        }

        private void OnFinished()
        {
            m_gamestateMachine.Enter<GameOverState>();
        }

        public override void Exit()
        {
            m_stick.Reset();
            m_upgradePanel?.SetActive(false);
            m_levelController.enabled = false;
            m_playerController.enabled = false;
            m_gameplayPanel.SetActive(false);
            m_levelController.Finished -= OnFinished;
        }
        private void OnScoreChanged(int score)
        {
            m_scoreText.text = score.ToString();
        }
    }
}
