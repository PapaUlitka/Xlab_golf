using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class AchivementManager : MonoBehaviour
    {
        [SerializeField] private Image[] m_achImages;
        [SerializeField] private bool[] m_isActive;
        [SerializeField] private ScoreManager m_score;
        void Update()
        {
            if (!m_isActive[0] && m_score.score >= 5)
            {
                m_isActive[0] = true;
                m_achImages[0].color = Color.green;
            }
            if (!m_isActive[1] && m_score.score >= 10)
            {
                m_isActive[1] = true;
                m_achImages[1].color = Color.green;
            }
        }
    }
}
