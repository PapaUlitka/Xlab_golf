using TMPro;
using UnityEngine;

namespace Golf
{
    public class GameplayState : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private ScoreManager m_scoreManager;
        [SerializeField] private PlayerController m_playerController;
        [SerializeField] private LevelController m_levelController;

        private GameStateMachine m_gamestateMachine;
        public void Initialize(GameStateMachine gameStateMachine)
        {
            m_scoreText.gameObject.SetActive(false);
            m_gamestateMachine = gameStateMachine;
        }
        public void Enter()
        {
            m_scoreManager.Reset();


            m_levelController.enabled = true;
            m_playerController.enabled = true;
        }
        public void Exit()
        {

        }
    }
}
