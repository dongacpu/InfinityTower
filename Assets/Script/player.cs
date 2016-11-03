using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class player : MonoBehaviour {

    public enum STATE_gun
    {
        havegun,
        nogun
    }

    public STATE_gun SG;

    public int damage;
    public int magazine;
    public int bullet;
    public float reload;
    public int velocity;
    public float shotdelay;
    public int range;
    public int buckshot;
    public bool auto;
    public bool guied;
    public float guied_value;
    public GameObject inventory;
    public GameObject gameobject_dropgun;

    private bool check_drop;
    private float time_drop;
    private GameObject gun;
    public bool check_item;
    // Use this for initialization
    void Start() {
        gun = GameObject.Find("gun");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            if (inventory.activeSelf)
                inventory.SetActive(false);
            else
                inventory.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            check_drop = true;
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            check_drop = false;
            time_drop = 0;
        }
        if (check_drop)
            time_drop += Time.deltaTime;
        if (time_drop > 0.5)
        {
            drop_gun();
            time_drop = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            check_item = true;
        }
    }
    void drop_gun() {
        if (SG == STATE_gun.havegun)
        {
            SG = STATE_gun.nogun;
            Vector3 dropspot = transform.FindChild("gun").transform.position;
            GameObject dropgun = (GameObject)Instantiate(gameobject_dropgun, dropspot, Quaternion.identity);
            dropgun.GetComponent<SpriteRenderer>().sprite = transform.FindChild("gun").GetComponent<SpriteRenderer>().sprite;
            gun.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("item")&&check_item==true)
        {

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("item"))
            check_item = false;
    }
}
