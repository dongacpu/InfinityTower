using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class inventory_ui : MonoBehaviour {
    public Image[] guni;
    public Image[] stuffi;
    public Image[] passivei;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Uiset() {
        for(int i=0;i<inventory.INSTANCE.InventoryGun.Count;i++)
        {
            guni[i].sprite = GunManager.INSTANCE.sprite[inventory.INSTANCE.InventoryGun[i].ID];
        }
        for (int i = 0; i < inventory.INSTANCE.InventoryStuff.Count; i++)
        {
            stuffi[i].sprite = StuffManager.INSTANCE.sprite[inventory.INSTANCE.InventoryStuff[i].ID];
        }
        for (int i = 0; i < inventory.INSTANCE.InventoryPassive.Count; i++)
        {
           passivei[i].sprite = PassiveManager.INSTANCE.sprite[inventory.INSTANCE.InventoryPassive[i].ID];
        }
    }
}
