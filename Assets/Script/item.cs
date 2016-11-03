using UnityEngine;
using System.Collections;

public class item : MonoBehaviour {
    bool ground;
    Rigidbody rigidbody;

    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.up*5, ForceMode.Impulse);
	}
	
	void Update () {
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
