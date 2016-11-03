using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour {
    private static ItemManager m_pInstance;

    private static object m_pLock = new object();

    public static ItemManager INSTANCE
    {
        get
        {
            lock(m_pLock)
            {
                if(m_pInstance == null)
                {
                        GameObject singleton = new GameObject();
                        m_pInstance = singleton.AddComponent<ItemManager>();
                        singleton.name = typeof(ItemManager).ToString();
                        DontDestroyOnLoad(singleton);  					
                }
            }

            return m_pInstance;
        }
    }

    // 파싱한 정보를 다 저장할꺼에요.
    Dictionary<int, ItemInfo> m_dicData = new Dictionary<int, ItemInfo>();
	// 아이템 추가.
    public void AddItem(ItemInfo _cInfo)
    {
        // 아이템은 고유해야 되니까, 먼저 체크!
        if (m_dicData.ContainsKey(_cInfo.ID)) return;

        // 이제 아이템을 추가.
        m_dicData.Add(_cInfo.ID, _cInfo);
    }
    // 하나의 아이템 얻기
    public ItemInfo GetItem(int _nID)
    {
        // 있는지 체크 해야겠죠?
        if (m_dicData.ContainsKey(_nID))
            return m_dicData[_nID];

        // 없으면 null 리턴!
        return null;
    }
    // 전체 리스트 얻기
    public Dictionary<int, ItemInfo> GetAllItems()
    {
        return m_dicData;
    }
    // 전체 갯수 얻기
    public int GetItemsCount()
    {
        return m_dicData.Count;
    }
}
public class ItemInfo
{
    private int m_iID;
    private string m_strName;
    private int m_iDamage;
    private int m_iMagazine;
    private int m_iBullet;
    private float m_fReload;
    private int m_iVelocity;
    private float m_fShotdelay;
    private int m_iRange;
    private int m_iBuckshot;
    private bool m_bAuto;

    public int ID
    {
        set { m_iID = value; }
        get { return m_iID; }
    }
    public string NAME
    {
        set { m_strName = value; }
        get { return m_strName; }
    }
    public int DAMAGE
    {
        set { m_iDamage = value; }
        get { return m_iDamage; }
    }
    public int MAGAZINE
    {
        set { m_iMagazine = value; }
        get { return m_iMagazine; }
    }
    public int BULLET
    {
        set { m_iBullet = value; }
        get { return m_iBullet; }
    }
    public float RELOAD
    {
        set { m_fReload = value; }
        get { return m_fReload; }
    }
    public int VELOCITY
    {
        set { m_iVelocity = value; }
        get { return m_iVelocity; }
    }
    public float SHOTDELAY
    {
        set { m_fShotdelay = value; }
        get { return m_fShotdelay; }
    }
    public int RANGE
    {
        set { m_iRange = value; }
        get { return m_iRange; }
    }
    public int BUCKSHOT
    {
        set { m_iBuckshot = value; }
        get { return m_iBuckshot; }
    }
    public bool AUTO
    {
        set { m_bAuto = value; }
        get { return m_bAuto; }
    }
}