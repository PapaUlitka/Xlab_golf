using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class GameOverState : MonoBehaviour
    {
        [SerializeField] private GameOverState m_gameOverPanel;

        private GameStateMachine m_gameStateMachine;

        public void Initialize(GameStateMachine gameStateMachine)
        {

        }
        public void Enter()
        {

        }
        public void Exit() { }
    }
}
