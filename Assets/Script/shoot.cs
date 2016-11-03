using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shoot : MonoBehaviour {
    public GameObject bullet;
    public player p;
    public Text t;
    move m;
    int magazine;
    public bool shoot_pos=true;
    public bool reload_check;
	// Use this for initialization
	void Start () {
        m = GameObject.Find("Player").GetComponent<move>();
        magazine = p.magazine;
	}

	// Update is called once per frame
	void Update () {

        t.text = magazine+"";
        if (magazine == 0)
            shoot_pos = false;
        if (Input.GetKeyDown(KeyCode.Mouse0) && magazine == 0&&p.SG==player.STATE_gun.havegun)
        {
            Reload();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) &&!p.auto && p.SG == player.STATE_gun.havegun)
        {
            Shoot();
        }
        if (Input.GetKey(KeyCode.Mouse0) && p.auto && p.SG == player.STATE_gun.havegun)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && p.SG == player.STATE_gun.havegun)
        {
            Reload();
        }
        
	}
    void Shoot()
    {
        if (shoot_pos)
        {
            for (int i = 0; i < p.bullet; i++)
                Instantiate(bullet);
            magazine--;
            StartCoroutine("wait", p.shotdelay);
        }
    }
    IEnumerator wait(float time) {
        shoot_pos = false;
        Debug.Log("총쏨");
        yield return new WaitForSeconds(time);
        if(!reload_check)
        shoot_pos = true;
    }
    IEnumerator reload(float time) {
        shoot_pos = false;
        reload_check = true;
        yield return new WaitForSeconds(time);
        reload_check = false;
        shoot_pos = true;
        magazine = p.magazine;
    }
    public void Reload()
    {
        StartCoroutine("reload", p.reload);
   
    }
}
