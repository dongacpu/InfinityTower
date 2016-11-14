using UnityEngine;
using System.Collections;

public class item : MonoBehaviour {
    bool ground;
    Rigidbody rigidbody;
    public int ID;
    public int ammo;
    public int magazine;
    public reload_state RS;

    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        GetComponent<SpriteRenderer>().sprite = GunManager.INSTANCE.sprite[ID];
        rigidbody.AddForce(Vector3.up*5, ForceMode.Impulse);
        if (ammo == 0)
        {
            ammo = GunManager.INSTANCE.GetItem(ID).AMMO;
            magazine = GunManager.INSTANCE.GetItem(ID).MAGAZINE;
            RS = reload_state.cant_reload;
        }
        else
            Debug.Log("drop");
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
