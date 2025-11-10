using NUnit.Framework;
using UnityEngine;

public class SwapItems : MonoBehaviour
{
    [SerializeField] private GameObject[] m_items;
    public SwapItems[] m_swapitems;
    private void Swap()
    {
        int index = Random.Range(0, m_items.Length);
        for (int i = 0;  i < m_items.Length; i++)
        {
            m_items[i].SetActive(i==index);
        }
    }
    public void Chage()
    {
        foreach(var change in m_swapitems)
        {
            change.Swap();
        }
    }
}