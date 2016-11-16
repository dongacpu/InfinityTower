using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PassiveManager : MonoBehaviour {
    private static PassiveManager m_pInstance;

    private static object m_pLock = new object();
    public Sprite[] sprite;
    public static PassiveManager INSTANCE
    {
        get
        {
            lock (m_pLock)
            {
                if (m_pInstance == null)
                {
                    GameObject singleton = new GameObject();
                    m_pInstance = singleton.AddComponent<PassiveManager>();
                    singleton.name = typeof(PassiveManager).ToString();
                    DontDestroyOnLoad(singleton);
                }
            }

            return m_pInstance;
        }
    }

    Dictionary<int, PassiveInfo> m_dicData = new Dictionary<int, PassiveInfo>();
    public void AddItem(PassiveInfo _cInfo)
    {
        if (m_dicData.ContainsKey(_cInfo.ID)) return;

        m_dicData.Add(_cInfo.ID, _cInfo);
    }

    public PassiveInfo GetItem(int _nID)
    {

        if (m_dicData.ContainsKey(_nID))
            return m_dicData[_nID];

        return null;
    }

    public Dictionary<int, PassiveInfo> GetAllItems()
    {
        return m_dicData;
    }

    public int GetItemsCount()
    {
        return m_dicData.Count;
    }
}
public class PassiveInfo
{
    private int m_iID;

    public int ID
    {
        set { m_iID = value; }
        get { return m_iID; }
    }
}
