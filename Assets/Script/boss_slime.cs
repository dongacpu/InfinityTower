using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class boss_slime: MonoBehaviour
{
    public float jump;
    public float speed;
    public float bossdamage;
    float patternjump;
    float checktime;
    public player bm;
    bullet bl;

    public Slider HPbar;

    enum state
    {
        pattern1, pattern2, pattern3
    }

    new Vector3 dis;

    state ST;
    Rigidbody rig;

    public bool fly = false;
    float flychecktime;
    bool patterncheck = true;
    float patternchecktime;
    bool jumpcheck = false;

    GameObject clone;
    GameObject clone1;

    public float HP;
    float current_hp;
    public float max_hp;
    public float count;

    enum hpstate
    {
        st_one,
        st_two,
        st_three
    }
    hpstate hs;
    // Use this for initialization
    void Start()
    {
        ST = state.pattern1;
        bm = GameObject.Find("Player").GetComponent<player>();
        rig = GetComponent<Rigidbody>();
        patternjump = jump * 3;
        current_hp = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (fly)
        {
            if (Time.time - flychecktime > 0.3f)
            {
                if (Time.time - flychecktime > 3f)
                {
                    rig.useGravity = true;
                }
                else
                {
                    transform.position = new Vector3(Mathf.Lerp(transform.position.x, bm.transform.position.x, Time.deltaTime * 2), transform.position.y, transform.position.z);
                    rig.useGravity = false;
                    rig.velocity = Vector3.zero;
                    dis = bm.transform.position - this.transform.position;
                }
            }
        }
        else
        {
            transform.Translate(new Vector3(dis.x, 0, 0) * Time.deltaTime * speed);
            if (patterncheck)
            {
                patternchecktime = Time.time;
                patterncheck = false;
            }
            if (!patterncheck)
            {
                if (Time.time - patternchecktime > 7f)
                {
                    ST = state.pattern2;
                    patterncheck = true;
                }
            }
        }
        if (HP <= current_hp / 2 && count > 0)
        {
            count--;
            clone = this.gameObject;
            clone1 = this.gameObject;
            Debug.Log(clone.transform.localScale.x);
            clone.transform.localScale = new Vector3(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f, 0);
            Debug.Log(clone.transform.localScale.x);
            clone = (GameObject)Instantiate(clone, new Vector3(transform.position.x + 1, transform.position.y, 0), transform.rotation);
            clone1 = (GameObject)Instantiate(clone1, new Vector3(transform.position.x - 1, transform.position.y, 0), transform.rotation);
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("bottom"))
        {
            jumpcheck = false;
            dis =   bm.transform.position-this.transform.position;
            dis /= -Vector3.Distance( bm.transform.position,transform.position);
            if (ST == state.pattern2 && !jumpcheck)
            {
                rig.AddForce(Vector3.up * patternjump);
                ST = state.pattern1;
                flychecktime = Time.time;
                fly = true;
                jumpcheck = true;
            }
        }
        if (ST == state.pattern1 && !jumpcheck)
        {
            Debug.Log("jump");
            rig.AddForce(Vector3.up * jump);
            fly = false;
            jumpcheck = true;
        }
        if (HP < 0)
        {
            Debug.Log("des");
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
            HP -= other.transform.GetComponent<bullet>().damage;
            Debug.Log(HP);
            //HPbar.value = HP / max_hp;
        }
    }
}
