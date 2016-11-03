using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{

    public int size;
    public Button button;

	void Start () {

        Debug.Log(ItemManager.INSTANCE.GetItemsCount());
        size = ItemManager.INSTANCE.GetItemsCount();
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
}
