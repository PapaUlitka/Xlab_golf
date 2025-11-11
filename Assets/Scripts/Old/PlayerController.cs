using UnityEngine;

namespace Old
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private FreeCamera m_camera;
        [SerializeField] private GameObject m_uiPanel;
        [SerializeField] private CloudController m_cloudController;
        [SerializeField] private SwapItems m_swapItems;
        void Update()
        {
            if (m_uiPanel.activeSelf)
            {
                return;
            }
            m_camera.Move();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_cloudController.MoveNext();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                m_swapItems.Chage();
            }
        }
    }
}