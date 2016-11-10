using UnityEngine;
using System.Collections;

public class item : MonoBehaviour {
    bool ground;
    Rigidbody rigidbody;
    public int ID;
    public int ammo;

    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        GetComponent<SpriteRenderer>().sprite = GunManager.INSTANCE.sprite[ID];
        rigidbody.AddForce(Vector3.up*5, ForceMode.Impulse);    
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
