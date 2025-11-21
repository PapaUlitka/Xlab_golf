using System;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class GameplayState : StateBase
    {
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private ScoreManager m_scoreManager;
        [SerializeField] private PlayerController m_playerController;
        [SerializeField] private LevelController m_levelController;
        [SerializeField] private GameObject m_gameplayPanel;

        private GameStateMachine m_gamestateMachine;
        public override void Initialize(GameStateMachine gameStateMachine)
        {
            m_gameplayPanel.SetActive(false);
            m_scoreText.gameObject.SetActive(false);
            m_gamestateMachine = gameStateMachine;
        }
        public override void Enter()
        {
            m_scoreManager.Reset();
            m_scoreManager.ScoreChanged += OnScoreChanged;
            OnScoreChanged(m_scoreManager.score);
            m_gameplayPanel.SetActive(true);


            m_levelController.enabled = true;
            m_playerController.enabled = true;
            m_levelController.Initialize();
            m_levelController.Finished += OnFinished;
        }

        private void OnFinished()
        {
            m_gamestateMachine.Enter<GameOverState>();
        }

        public override void Exit()
        {
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
