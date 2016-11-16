using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum reload_state {
    can_reload,
    cant_reload,
    must_reload,
    reloading,
    shooting
}   

public class shoot : MonoBehaviour {
    public GameObject bullet;
    public player p;
    public Text magazine_current;
    public Slider reload_gagebar;
    public ParticleSystem muzzleflash;
    public bool reload_check=true;
    public float reload_time=0;
    public float reload_time_max;


    move m;

	void Start () {
        m = GameObject.Find("Player").GetComponent<move>();
	}

	void Update () {
        if (p.num_havegun > 0)
            magazine_current.gameObject.SetActive(true);
        else
            magazine_current.gameObject.SetActive(false);
        if (p.ammo != -1)
            magazine_current.text = p.ammo + "/" + p.magazine_current;
        else
            magazine_current.text = "무한 /" + p.magazine_current;
        reload_time_max = p.reload;

        if (Input.GetKeyDown(KeyCode.Mouse0)&&p.RS==reload_state.must_reload&& (p.SG == player.STATE_gun.havegun || p.SG == player.STATE_gun.fullgun))
        {
            Reload();
        }
        if (Input.GetKeyDown(KeyCode.R) && (p.SG == player.STATE_gun.havegun || p.SG == player.STATE_gun.fullgun)&&(p.RS==reload_state.can_reload|| p.RS == reload_state.must_reload))
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
        if (p.change)
        {
            reload_time = 0;
            reload_gagebar.gameObject.SetActive(false);
            p.change = false;
            StopCoroutine("reload");
        }
        if (p.RS==reload_state.reloading)
        {
            reload_time += Time.deltaTime;
            reload_gagebar.value = reload_time/reload_time_max;
            Vector3 pos = Camera.main.WorldToScreenPoint(p.transform.position+Vector3.up*474*0.5f*0.4f*0.01f);//474캐릭터 픽셀
            reload_gagebar.gameObject.transform.position = new Vector3(pos.x, pos.y, 0);
        }       
	}
    void Shoot()
    {
        if (!(p.RS==reload_state.must_reload||p.RS==reload_state.reloading||p.RS==reload_state.shooting))
        {
            for (int i = 0; i < p.bullet; i++)
                Instantiate(bullet);
            p.magazine_current--;
            p.RS = reload_state.can_reload;
            muzzleflash.Play();
            StartCoroutine("wait", p.shotdelay);
            
        }
    }
    IEnumerator wait(float time) {
        p.RS = reload_state.shooting;
        yield return new WaitForSeconds(time);
        
        if (p.magazine_current == 0)
            p.RS = reload_state.must_reload;
        else
            p.RS = reload_state.can_reload;
    }
    IEnumerator reload(float time) {
        int temp = p.num_currentgun;
        reload_time = 0;
        reload_gagebar.gameObject.SetActive(true);
        p.RS = reload_state.reloading;
        yield return new WaitForSeconds(time);
        if (temp==p.num_currentgun) {
            reload_gagebar.gameObject.SetActive(false);
            p.magazine_current = p.magazine;
            if (p.ammo != -1)
                p.ammo -= p.magazine;
            p.RS = reload_state.cant_reload;
        }
    }
    public void Reload()
    {
        if (p.ammo > 0 || p.ammo == -1)
            StartCoroutine("reload", p.reload);
       
    }
}
