using UnityEngine;
using System.Collections;

public class aim : MonoBehaviour {

    public Texture2D cursortexture;
    public Vector2 hotspot;
    Vector3 cursorposition;
    public move m;
	void Start () {
        
        hotspot = new Vector2(cursortexture.width / 2, cursortexture.height / 2);
        Cursor.SetCursor(cursortexture, hotspot, CursorMode.Auto);

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (cursorposition.x < m.transform.position.x)
        {
            m.direction = false;
            m.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            m.direction = true;
            m.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        cursorposition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
       
       
        if(cursorposition.x < m.transform.position.x)
            transform.rotation = Quaternion.Euler(+180, 0, -90+Mathf.Atan2(cursorposition.x - transform.position.x, cursorposition.y - transform.position.y-58*0.5f*0.01f) * Mathf.Rad2Deg);
        else
            transform.rotation = Quaternion.Euler(0, 0, +90 - Mathf.Atan2(cursorposition.x - transform.position.x, cursorposition.y - transform.position.y - 58 * 0.5f * 0.01f) * Mathf.Rad2Deg);
    }
}
