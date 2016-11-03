using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    public float speed;
    public float jump;
    public bool double_jump;
    public bool check_jump;
    public bool direction=true;//false==왼쪽, true==오른쪽
    Rigidbody rigidbody;
    shoot Shoot;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        Shoot = GetComponent<shoot>();
	}

    void FixedUpdate() {
       
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (double_jump)
            {
                double_jump = false;
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
                rigidbody.AddForce(Vector3.up * jump);
                Debug.Log("더블점프");
            }
            else if (check_jump)
            {
                check_jump = false;
                rigidbody.AddForce(Vector3.up * jump);
                double_jump = true;
                Debug.Log("점프");
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if(direction)
                transform.Translate(Vector2.left * Time.deltaTime * speed);
            else
                transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (direction)
                transform.Translate(Vector2.right * Time.deltaTime * speed);
            else
                transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        
    }
    void OnCollisionEnter(Collision other) {
        if (other.transform.CompareTag("bottom"))
        {
            check_jump = true;
            double_jump = false;
        }

    }
}
