using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunManager : MonoBehaviour {
    private static GunManager m_pInstance;

    private static object m_pLock = new object();
    public Sprite[] sprite;
    public static GunManager INSTANCE
    {
        get
        {
            lock(m_pLock)
            {
                if(m_pInstance == null)
                {
                        GameObject singleton = new GameObject();
                        m_pInstance = singleton.AddComponent<GunManager>();
                        singleton.name = typeof(GunManager).ToString();
                        
                        DontDestroyOnLoad(singleton);  					
                }
            }

            return m_pInstance;
        }
    }

    Dictionary<int, GunInfo> m_dicData = new Dictionary<int, GunInfo>();
    public void AddItem(GunInfo _cInfo)
    { 
        if (m_dicData.ContainsKey(_cInfo.ID)) return;

        m_dicData.Add(_cInfo.ID, _cInfo);
    }

    public GunInfo GetItem(int _nID)
    {

        if (m_dicData.ContainsKey(_nID))
            return m_dicData[_nID];

        return null;
    }

    public Dictionary<int, GunInfo> GetAllItems()
    {
        return m_dicData;
    }

    public int GetItemsCount()
    {
        return m_dicData.Count;
    }
}
public class GunInfo
{
    private int m_iID;
    private string m_strName;
    private int m_iDamage;
    private int m_ammo;
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
    public int AMMO {
        set { m_ammo = value; }
        get { return m_ammo; }
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
