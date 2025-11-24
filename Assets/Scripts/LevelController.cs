using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public event Action Finished;

        [SerializeField] private int m_missedCount;
        [SerializeField] [Min(0)] private float m_spawnRate = 0.5f;
        [SerializeField] private StoneSpawner m_stoneSpawner;
        [SerializeField] private ScoreManager m_scoreManager;

        private float m_time;
        private int m_currentMissedCount;
        private List<StoneComponent> m_stones;

        private void Awake()
        {
            m_stones = new List<StoneComponent>();
            
        }
        public void Initialize()
        {
            m_currentMissedCount = m_missedCount;
        }

        private void Start()
        {
            m_time = m_spawnRate;
        }
        void Update()
        {
            m_time += Time.deltaTime;
            if (m_time >= m_spawnRate)
            {
                StoneComponent stone = m_stoneSpawner.Spawn();
                m_stones.Add(stone);
                stone.Hit += OnHitStone;
                stone.Missed += OnMissed;
                m_time = 0;
            }
              
        }

        private void OnHitStone(StoneComponent stone)
        {
            UnsubscribeStone(stone);
            m_scoreManager.Increase();
        }

        private void OnMissed(StoneComponent stone)
        {
            UnsubscribeStone(stone);

            m_currentMissedCount--;
            if (m_currentMissedCount <= 0)
            {
                Debug.Log("GameOver");
                Finished?.Invoke();

                foreach(var item in m_stones)
                {
                    Destroy(item.gameObject);
                }
                m_stones.Clear();
            }
        }
        private void UnsubscribeStone(StoneComponent stone)
        {
            stone.Hit -= OnHitStone;
            stone.Missed -= OnMissed;
        }

    }

}