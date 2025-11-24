using System;
using UnityEngine;

namespace Golf
{
    public class ScoreManager : MonoBehaviour
    {
        public event Action<int> ScoreChanged;
        public event Action<int> RecordChanged;

        private int m_score;
        public int score
        {
            get => m_score;
            set
            {
                m_score = value;
                Debug.Log($"Score: {value}");
                ScoreChanged?.Invoke(value);
            }
        }
        public int record
        {
            get
            {
                PlayerPrefs.DeleteKey(GlobalConstants.Record);
                return PlayerPrefs.GetInt(GlobalConstants.Record, 100);
            }
            private set
            {
                if(record < value)
                {
                    PlayerPrefs.SetInt(GlobalConstants.Record, value);
                    RecordChanged?.Invoke(value);
                }
            }
        }


        public void Reset()
        {
            score = 0;
        }

        public void Increase()
        {
            score++;
        }
        public void UpdateRecord() => record = score;
    }
}
