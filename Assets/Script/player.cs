using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class player : MonoBehaviour {

    public enum STATE_gun
    {
        havegun,
        fullgun,
        nogun
    }
    public STATE_gun SG;
    public GameObject Inventory;
    public GameObject gameobject_dropgun;
    #region public
    public int damage;             //현재 총기 데미지
    public int ammo;               //현재 총기 총알수
    public int magazine;           //현재 총기 최대장탄수
    public int bullet;             //현재 총기 발사 총알수
    public float reload;           //현재 총기 재장전 시간
    public int velocity;           //현재 총기 총알속도
    public float shotdelay;        //현재 총기 발사 딜레이
    public int range;              //현재 총기 총알 사정거리
    public int buckshot;           //현재 총기 산탄도
    public bool auto;              //현재 총기 자동유무
    public bool guied;             //현재 총기 유도 유무
    public float guied_value;      //현재 총기 유도 정도
    public int magazine_current;   //현재 장탄수
    public int num_currentgun = 0;      //현재 총기 번호
    public bool change = false;
    public reload_state RS;
    #endregion
    private bool check_drop;        //총 버림 체크
    private float time_drop;        //총 버림 버튼 누른시간
    private GameObject gun;         //총 오브젝트
    private Collider get_item;      //먹은 총기
    private GunManager GM;          //총기 매니저
    private int num_currentgun_ID=0;   //현재 총기 ID
    private  int num_havegun = 0;    //가지고 있는 총기수
    private int num_limitgun = 4;   //최대 총기수

    
   

    void Start()
    {
        gun = GameObject.Find("gun");
      //  magazine_current = new int[4];
    }

    void Update()
    {
        if (num_havegun == 0)
            SG = STATE_gun.nogun;
        else if (num_havegun == num_limitgun)
            SG = STATE_gun.fullgun;
        else
            SG = STATE_gun.havegun;
        if (Input.GetKeyDown(KeyCode.Alpha1)&&num_havegun>=1&&num_currentgun!=0)
        {
            if (RS == reload_state.reloading)
                inventory.INSTANCE.setgun(num_currentgun, ammo, magazine_current, num_currentgun_ID, reload_state.must_reload);
            else
                inventory.INSTANCE.setgun(num_currentgun, ammo, magazine_current, num_currentgun_ID, RS);
            change = true;
            num_currentgun = 0;
            change_gun();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && num_havegun >= 2 && num_currentgun != 1)
        {
            if (RS == reload_state.reloading)
                inventory.INSTANCE.setgun(num_currentgun, ammo, magazine_current, num_currentgun_ID, reload_state.must_reload);
            else
                inventory.INSTANCE.setgun(num_currentgun, ammo, magazine_current, num_currentgun_ID, RS);
            change = true;
            num_currentgun = 1;
            change_gun();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && num_havegun >= 3 && num_currentgun != 2)
        {
            if (RS == reload_state.reloading)
                inventory.INSTANCE.setgun(num_currentgun, ammo, magazine_current, num_currentgun_ID, reload_state.must_reload);
            else
                inventory.INSTANCE.setgun(num_currentgun, ammo, magazine_current, num_currentgun_ID, RS);
            change = true;
            num_currentgun = 2;
            change_gun();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && num_havegun >= 4 && num_currentgun != 3)
        {
            if (RS == reload_state.reloading)
                inventory.INSTANCE.setgun(num_currentgun, ammo, magazine_current, num_currentgun_ID, reload_state.must_reload);
            else
                inventory.INSTANCE.setgun(num_currentgun, ammo, magazine_current, num_currentgun_ID, RS);
            change = true;
            num_currentgun = 3;
            change_gun();
        }
        if (Input.GetKeyDown(KeyCode.I)) {
            if (Inventory.activeSelf)
                Inventory.SetActive(false);
            else
                Inventory.SetActive(true);
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
            time_drop = 0;
            drop_gun();
        }
        if (Input.GetKeyDown(KeyCode.E)&&get_item!=null)
        {
            get_gun();
        }
    }
    void get_gun() {
        if (SG!=STATE_gun.fullgun) {
            item temp = get_item.GetComponent<item>();
            inventory.INSTANCE.addgun(temp.ammo, temp.magazine, temp.ID, temp.RS);
            Destroy(get_item.gameObject);
            if (SG != STATE_gun.nogun)
            {
                inventory.INSTANCE.setgun(num_currentgun, ammo, magazine_current, num_currentgun_ID, RS);
            }
            num_havegun++;
            num_currentgun = num_havegun - 1;
            change_gun();   
        }
    }
    void drop_gun() {
        if (SG != STATE_gun.nogun)
        {
            Vector3 dropspot = transform.FindChild("gun").transform.position;
            GameObject dropgun = (GameObject)Instantiate(gameobject_dropgun, dropspot, Quaternion.identity);
            dropgun.GetComponent<item>().ID = num_currentgun_ID;
            dropgun.GetComponent<item>().ammo = ammo;
            dropgun.GetComponent<item>().magazine = magazine_current;
            if (RS == reload_state.reloading)
                dropgun.GetComponent<item>().RS = reload_state.must_reload;
            else
                dropgun.GetComponent<item>().RS = RS;
            change = true;
            gun.GetComponent<SpriteRenderer>().enabled = false;
            inventory.INSTANCE.deletegun(num_currentgun);
            num_havegun--;
            if (num_havegun!=0)
            {
                if (num_currentgun == num_havegun)
                {
                    num_currentgun--;
                    change_gun();
                }
                else
                {
                    change_gun();
                }
            }
        }
    }
    void change_gun()
    {
        Gun temp = inventory.INSTANCE.getgun(num_currentgun);
        num_currentgun_ID = temp.ID;
        GunInfo g = GunManager.INSTANCE.GetItem(num_currentgun_ID);
        transform.FindChild("gun").GetComponent<SpriteRenderer>().sprite = GunManager.INSTANCE.sprite[num_currentgun_ID];
        transform.FindChild("gun").GetComponent<SpriteRenderer>().enabled = true;
        damage = g.DAMAGE;
        magazine =g.MAGAZINE;
        bullet =g.BULLET;
        reload = g.RELOAD;
        velocity = g.VELOCITY;
        shotdelay = g.SHOTDELAY;
        range = g.RANGE;
        buckshot = g.BUCKSHOT;
        auto = g.AUTO;
        ammo = temp.AMMO;
        magazine_current = temp.MAGAZINE;
        RS = temp.RS_;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("item"))
        {
            get_item = other;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("item"))
        {
            get_item = null;
        }
    }
}
