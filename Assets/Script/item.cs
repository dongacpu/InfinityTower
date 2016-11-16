using UnityEngine;
using System.Collections;

public class item : MonoBehaviour {
    bool ground;
    Rigidbody rigidbody;
    public int ID;
    public int ammo;
    public int magazine;
    public bool drop;
    public reload_state RS;
    public enum itemtype{
        active,
        passive,
        gun,
        stuff
    }
    public itemtype IT;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
        if (IT == itemtype.gun)
        {
            GetComponent<SpriteRenderer>().sprite = GunManager.INSTANCE.sprite[ID];
            if (!drop)
            {
                ammo = GunManager.INSTANCE.GetItem(ID).AMMO;
                magazine = GunManager.INSTANCE.GetItem(ID).MAGAZINE;
                RS = reload_state.cant_reload;
            }
        }
        else if (IT == itemtype.stuff)
        {
            GetComponent<SpriteRenderer>().sprite = StuffManager.INSTANCE.sprite[ID];
        }
        else if (IT == itemtype.passive)
        {
            GetComponent<SpriteRenderer>().sprite = StuffManager.INSTANCE.sprite[ID];    
        }
    }
	
	void Update () {
        if (rigidbody.velocity.y < -3)
            rigidbody.velocity = new Vector2(0, -3);
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bottom"))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.useGravity = false;
        }
    }
}
