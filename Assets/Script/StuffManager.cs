using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StuffManager : MonoBehaviour {
    private static StuffManager m_pInstance;

    private static object m_pLock = new object();
    public Sprite[] sprite;
    public static StuffManager INSTANCE
    {
        get
        {
            lock (m_pLock)
            {
                if (m_pInstance == null)
                {
                    GameObject singleton = new GameObject();
                    m_pInstance = singleton.AddComponent<StuffManager>();
                    singleton.name = typeof(StuffManager).ToString();
                    DontDestroyOnLoad(singleton);
                }
            }

            return m_pInstance;
        }
    }

    Dictionary<int, StuffInfo> m_dicData = new Dictionary<int, StuffInfo>();
    public void AddItem(StuffInfo _cInfo)
    {
        if (m_dicData.ContainsKey(_cInfo.ID)) return;

        m_dicData.Add(_cInfo.ID, _cInfo);
    }

    public StuffInfo GetItem(int _nID)
    {

        if (m_dicData.ContainsKey(_nID))
            return m_dicData[_nID];

        return null;
    }

    public Dictionary<int, StuffInfo> GetAllItems()
    {
        return m_dicData;
    }

    public int GetItemsCount()
    {
        return m_dicData.Count;
    }
}
public class StuffInfo
{
    private int m_iID;

    public int ID
    {
        set { m_iID = value; }
        get { return m_iID; }
    }
}
