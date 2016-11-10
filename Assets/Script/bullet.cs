using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    bool direction;
    bool guied;
    move m;
    shoot s;
    GameObject enemy;
    Vector3 Axis;
    float range=0;
    Vector3 mouseposition;
    Vector3 lookvector;
    GameObject bulletspot;
    float velocity;
    
    void Start()
    {
        s = GameObject.Find("gun").GetComponent<shoot>();
        m = GameObject.Find("Player").GetComponent<move>();
        guied = s.p.guied;
        enemy = GameObject.FindWithTag("Enemy");
        bulletspot = GameObject.Find("bulletspot");
        direction = m.direction;
        if (direction)
            transform.position = bulletspot.transform.position;
        else
            transform.position = bulletspot.transform.position;
        float buck = Random.Range(-s.p.buckshot, s.p.buckshot);
        transform.Rotate(Vector3.forward, buck);
        mouseposition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        lookvector = Vector3.Normalize(mouseposition - transform.position);
        velocity = s.p.velocity;
    }

    void Update()
    {
        if (guied)
        {
            
            Vector3 x = transform.position - enemy.transform.position;
            if (direction)
            {
                Axis = Vector3.Cross(x, transform.right);
            }
            else
            {
                Axis = Vector3.Cross(transform.right,x);   
            }
            transform.Rotate(Axis, s.p.guied_value);
        }
        if (direction)
        {
            transform.Translate(lookvector * velocity*2 * Time.deltaTime);
            range+=1*velocity*2*Time.deltaTime;
            
        }
       else
        {;
            transform.Translate(lookvector * velocity *2* Time.deltaTime);
            range += 1 * velocity * 2 * Time.deltaTime;
        }
       if (range >= s.p.range)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
