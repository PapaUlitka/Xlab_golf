using UnityEngine;
using UnityEngine.UIElements;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        [SerializeField] private float m_minAngleZ = -30;
        [SerializeField] private float m_maxAngleZ = 30;
        [SerializeField][Min(0)] private float m_speed;
        private void FixedUpdate()
        {
            var angels = transform.localEulerAngles;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                angels.z = Rotate(angels.z, m_minAngleZ);
            }
            else
            {
                angels.z = Rotate(angels.z, m_maxAngleZ);
            }
            transform.localEulerAngles = angels;
        }
        private float Rotate(float angleZ, float target)
        {
            return Mathf.MoveTowardsAngle(angleZ, target, m_speed * Time.deltaTime);
        }
    }
}
