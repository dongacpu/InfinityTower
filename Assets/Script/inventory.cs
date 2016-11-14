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

    public List<Gun> gun = new List<Gun>();
    public void addgun(int num, int num1, int num2, reload_state rs)
    {
        Gun temp = new Gun(num, num1, num2, rs);
        gun.Add(temp);
    }
    public Gun getgun(int num)
    {
        return gun[num];
    }
    public void deletegun(int num)
    {
        gun.RemoveAt(num);
    }
    public void setgun(int num, int num1, int num2, int num3, reload_state rs)
    {
        gun[num].AMMO = num1;
        gun[num].MAGAZINE = num2;
        gun[num].ID = num3;
        gun[num].RS_ = rs;
    }
}
[System.Serializable]
public class Gun
{
    public int ammo;
    public int magazine;
    public int id;
    public reload_state RS;
    public Gun(int num, int num2, int num3, reload_state rs)
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


