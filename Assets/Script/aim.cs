using UnityEngine;
using System.Collections;

public class aim : MonoBehaviour {

    public Texture2D cursortexture;
    public Vector2 hotspot;
    public GameObject head;
    Vector3 cursorposition;
    public move m;
	void Start () {
        
        hotspot = new Vector2(cursortexture.width / 2, cursortexture.height / 2);
        Cursor.SetCursor(cursortexture, hotspot, CursorMode.Auto);
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (cursorposition.x < m.transform.position.x)
        {
            m.direction = false;
            m.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            m.direction = true;
            m.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        cursorposition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));


        if (cursorposition.x < m.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(180, 180, Mathf.Atan2(cursorposition.y - transform.position.y, cursorposition.x - transform.position.x) * Mathf.Rad2Deg);
            head.transform.rotation = Quaternion.Euler(180, 180, Mathf.Atan2(cursorposition.y - transform.position.y-100*0.01f, cursorposition.x - transform.position.x) * Mathf.Rad2Deg);

        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, -Mathf.Atan2(cursorposition.y - transform.position.y, cursorposition.x - transform.position.x) * Mathf.Rad2Deg);
            head.transform.rotation = Quaternion.Euler(0, 180, -Mathf.Atan2(cursorposition.y - transform.position.y - 100 * 0.01f, cursorposition.x - transform.position.x) * Mathf.Rad2Deg);

        }
    }
}
