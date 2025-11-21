using UnityEngine;
using UnityEngine.UIElements;

namespace Golf
{
    public class StoneSpawner : MonoBehaviour
    {
        [SerializeField] private StoneComponent[] m_prefabs;
        [SerializeField] private Transform m_spawnPoint;
        [SerializeField] private int m_lowerBound;
        [SerializeField] private int m_upperBound;

        public StoneComponent Spawn()
        {
            var prefab = m_prefabs[Random.Range(0, m_prefabs.Length)];
            return Instantiate(prefab, m_spawnPoint.position = new Vector3(m_spawnPoint.position.x, Random.Range(m_lowerBound,m_upperBound) , m_spawnPoint.position.z), m_spawnPoint.rotation);
        }
    }
}