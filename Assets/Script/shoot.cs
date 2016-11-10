using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shoot : MonoBehaviour {
    public GameObject bullet;
    public player p;
    public Text magazine_current;
    public Slider reload_gagebar;
    public ParticleSystem muzzleflash;
    public bool shoot_pos=true;
    public bool reload_check=true;
    public float reload_time;
    public float reload_time_max;


    move m;

	void Start () {
        m = GameObject.Find("Player").GetComponent<move>();
        reload_check = true;
	}

	void Update () {
        magazine_current.text =p.ammo+"/"+ p.magazine_current;
        reload_time_max = p.reload;
        if (Input.GetKeyDown(KeyCode.Mouse0) &&reload_check&& p.magazine_current==0&&(p.SG==player.STATE_gun.havegun||p.SG==player.STATE_gun.fullgun))
        {
            Reload();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) &&!p.auto && (p.SG == player.STATE_gun.havegun || p.SG == player.STATE_gun.fullgun))
        {
            Shoot();
        }
        if (Input.GetKey(KeyCode.Mouse0) && p.auto && (p.SG == player.STATE_gun.havegun || p.SG == player.STATE_gun.fullgun))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && (p.SG == player.STATE_gun.havegun || p.SG == player.STATE_gun.fullgun))
        {
            Reload();
        }
        if (!reload_check)
        {
            reload_time += Time.deltaTime;
            reload_gagebar.value = reload_time/reload_time_max;
            Vector3 pos = Camera.main.WorldToScreenPoint(p.transform.position+Vector3.up*474*0.5f*0.4f*0.01f);//474캐릭터 픽셀
            reload_gagebar.gameObject.transform.position = new Vector3(pos.x, pos.y, 0);
        }       
	}
    void Shoot()
    {
        if (shoot_pos)
        {
            for (int i = 0; i < p.bullet; i++)
                Instantiate(bullet);
            p.magazine_current--;
            muzzleflash.Play();
            StartCoroutine("wait", p.shotdelay);
            
        }
    }
    IEnumerator wait(float time) {
        shoot_pos = false;
        yield return new WaitForSeconds(time);
        if(reload_check)
        shoot_pos = true;
        if (p.magazine_current == 0)
            shoot_pos = false;
    }
    IEnumerator reload(float time) {
        reload_time = 0;
        reload_gagebar.gameObject.SetActive(true);
        reload_check = false;
        shoot_pos = false;
        yield return new WaitForSeconds(time);
        reload_check = true;
        reload_gagebar.gameObject.SetActive(false);
        p.magazine_current = p.magazine;
        p.ammo -= p.magazine;
        shoot_pos = true;
    }
    public void Reload()
    {
        if(p.ammo>0)
        StartCoroutine("reload", p.reload);
    }
}
