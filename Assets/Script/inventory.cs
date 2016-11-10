using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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

    public List<int> gun = new List<int>();
    public List<int> ammo = new List<int>();
    public void AddItem(int num)
    {
        gun.Add(num);
    }
    public int Getitem(int num)
    {
        return gun[num];
    }
    public void deleteitem(int num) {
        gun.RemoveAt(num);
    }
    public void addammo(int num)
    {
        ammo.Add(num);
    }

}



//  public int size;
//  public Button button;
/* 
void Start () {

     Debug.Log(GunManager.INSTANCE.GetItemsCount());
      size = GunManager.INSTANCE.GetItemsCount();
      Transform Content = transform.FindChild("Viewport").transform.FindChild("Content").transform;
      if(size%2==0)
          Content.GetComponent<RectTransform>().sizeDelta=new Vector2(0,size/2*125+25);
      else
          Content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, (size+1) / 2 * 125 + 25);
      for (int i = 0; i < size; i++)
      {
              Button but = Instantiate(button) as Button;
              but.transform.parent = Content;
          if (i % 2 == 0)
              but.transform.localPosition = new Vector3(125, -i/2*125-75);
          else
              but.transform.localPosition = new Vector3(375, -i/2 * 125 -75);
      }
}

void Update () {

}
}*/
