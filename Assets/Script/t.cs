using UnityEngine;
using System.Collections;

public class t : MonoBehaviour {

    // Use this for initialization
    void Start() {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/gun");
   //     Debug.Log(Resources<Sprite>("Image/gun"));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
