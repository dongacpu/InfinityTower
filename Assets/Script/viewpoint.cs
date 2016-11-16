using UnityEngine;
using System.Collections;

public class viewpoint : MonoBehaviour {
    
    public GameObject A;
    Transform a;
    void Start()
    {
        a = A.transform;
    }
    void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x,a.position.x, Time.deltaTime*2f), Mathf.Lerp(transform.position.y, a.position.y,  Time.deltaTime *2f), -10);
    }
    /*1
    public GameObject A;
    Transform a;
    void Start()
    {
         a= A.transform;
    }
    void LateUpdate()
    {
        transform.position = new Vector3(a.position.x, a.position.y, transform.position.z);
    }*/
}
