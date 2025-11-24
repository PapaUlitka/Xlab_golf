using UnityEngine;
using UnityEngine.UIElements;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float m_power = 250;
        [SerializeField] private Transform m_point;
        [SerializeField] private float m_minAngleZ = -30;
        [SerializeField] private float m_maxAngleZ = 30;
        [SerializeField][Min(0)] private float m_speed;

        public float power
        {
            get => m_power;
            set
            {
                m_power = value;
            }
        }

        private bool m_isDown;
        private Vector3 m_lastPointPosition;
        private Vector3 m_direction;
        private void FixedUpdate()
        {
            var angels = transform.localEulerAngles;

            if (m_isDown)
            {
                angels.z = Rotate(angels.z, m_minAngleZ);
            }
            else
            {
                angels.z = Rotate(angels.z, m_maxAngleZ);
            }
            transform.localEulerAngles = angels;

            m_direction = (m_point.position - m_lastPointPosition).normalized;
            m_lastPointPosition = m_point.position;
        }

        private float Rotate(float angleZ, float target)
        {
            return Mathf.MoveTowardsAngle(angleZ, target, m_speed * Time.deltaTime);
        }
        private void OnCollisionEnter(Collision collision)
        {
            
            if (collision.gameObject.TryGetComponent<StoneComponent>(out var stone))
            {
                stone.AddForce(m_power * m_direction);
            }
        }
        public void Down() => m_isDown = true;
        public void Up() => m_isDown = false;
        public void Reset()
        {
            power = 500;
            transform.localScale = new Vector3(1,1,1);
        }
    }
}
