using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
[System.Serializable]
public class inventory : MonoBehaviour
{
    private static inventory singletone;
    private static object Lock = new object();


    public static inventory INSTANCE
    {
        get
        {
            lock (Lock)
            {
                if (singletone == null)
                {
                    GameObject singleton = new GameObject();
                    singletone = singleton.AddComponent<inventory>();
                    singleton.name = typeof(inventory).ToString();
                    DontDestroyOnLoad(singleton);
                }
            }

            return singletone;
        }
    }

    public List<InventoryGun> InventoryGun = new List<InventoryGun>();
    public List<InventoryStuff> InventoryStuff = new List<InventoryStuff>();
    public List<InventoryPassive> InventoryPassive = new List<InventoryPassive>();
    public void addgun(int num, int num1, int num2, reload_state rs)
    {
        InventoryGun temp = new InventoryGun(num, num1, num2, rs);
        InventoryGun.Add(temp);
    }
    public InventoryGun getInventoryGun(int num)
    {
        return InventoryGun[num];
    }
    public void deleteInventoryGun(int num)
    {
        InventoryGun.RemoveAt(num);
    }
    public void setInventoryGun(int num, int num1, int num2, int num3, reload_state rs)
    {
        InventoryGun[num].AMMO = num1;
        InventoryGun[num].MAGAZINE = num2;
        InventoryGun[num].ID = num3;
        InventoryGun[num].RS_ = rs;
    }
    public void addstuff(int num)
    {
        InventoryStuff temp = new InventoryStuff(num);
        InventoryStuff.Add(temp);
    }
    public void addpassive(int num)
    {
        InventoryPassive temp = new InventoryPassive(num);
        InventoryPassive.Add(temp);
    }
}
[System.Serializable]
public class InventoryGun
{
    private int ammo;
    private int magazine;
    private int id;
    private reload_state RS;
    public InventoryGun(int num, int num2, int num3, reload_state rs)
    {
        ammo = num;
        magazine = num2;
        id = num3;
        RS = rs;
    }
    public int AMMO
    {
        get { return ammo; }
        set { ammo = value; }
    }
    public int MAGAZINE
    {
        get { return magazine; }
        set { magazine = value; }
    }
    public int ID
    {
        get { return id; }
        set { id = value; }
    }
    public reload_state RS_
    {
        get { return RS; }
        set { RS = value; }
    }

}
[System.Serializable]
public class InventoryStuff
{
    private int id;
    public InventoryStuff(int num3)
    {
        id = num3;
    }
    public int ID
    {
        get { return id; }
        set { id = value; }
    }

}
[System.Serializable]
public class InventoryPassive
{
    private int id;
    public InventoryPassive(int num3)
    {
        id = num3;
    }
    public int ID
    {
        get { return id; }
        set { id = value; }
    }

}

