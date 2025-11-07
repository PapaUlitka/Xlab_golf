using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FreeCamera m_camera;
    [SerializeField] private GameObject m_uiPanel;
    [SerializeField] private CloudController m_cloudController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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
    }
}
