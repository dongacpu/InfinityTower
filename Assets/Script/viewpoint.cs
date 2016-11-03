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
        transform.position = Vector3.Lerp(transform.position, a.position, 2f * Time.deltaTime);
        transform.Translate(0, 0, -10); //카메라를 원래 z축으로 이동
    }
    /*
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
