using UnityEngine;

namespace Golf
{
    public class StoneComponent : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Earth"))
            {
                print("collide with earth");
            }
            if (collision.gameObject.CompareTag("Stick"))
            {
                print("collide with stick");
            }
        }
    }
}