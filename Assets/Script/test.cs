using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class test : MonoBehaviour {
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            ItemInfo item = ItemManager.INSTANCE.GetItem(0);
            Debug.Log("ID : " + item.ID + " | 이름 : " + item.NAME + " | 데미지 : " + item.DAMAGE + " | 장탄수 : " + item.MAGAZINE
                + " | 발사총알수 : " + item.BULLET + " | 장전속도 : " + item.RELOAD + " | 탄속도 : " +
                item.VELOCITY + " | 연사력 : " + item.SHOTDELAY + " | 사정거리 : " + item.RANGE + " | 산탄도 : " +
                item.BUCKSHOT + " | 연사가능성 : " + item.AUTO);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            ItemInfo item = ItemManager.INSTANCE.GetItem(1);
            Debug.Log("ID : " + item.ID + " | 이름 : " + item.NAME + " | 데미지 : " + item.DAMAGE + " | 장탄수 : " + item.MAGAZINE
                + " | 발사총알수 : " + item.BULLET + " | 장전속도 : " + item.RELOAD + " | 탄속도 : " +
                item.VELOCITY + " | 연사력 : " + item.SHOTDELAY + " | 사정거리 : " + item.RANGE + " | 산탄도 : " +
                item.BUCKSHOT + " | 연사가능성 : " + item.AUTO);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            ItemInfo item = ItemManager.INSTANCE.GetItem(2);
            Debug.Log("ID : " + item.ID + " | 이름 : " + item.NAME + " | 데미지 : " + item.DAMAGE + " | 장탄수 : " + item.MAGAZINE
                + " | 발사총알수 : " + item.BULLET + " | 장전속도 : " + item.RELOAD + " | 탄속도 : " +
                item.VELOCITY + " | 연사력 : " + item.SHOTDELAY + " | 사정거리 : " + item.RANGE + " | 산탄도 : " +
                item.BUCKSHOT + " | 연사가능성 : " + item.AUTO);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            ItemInfo item = ItemManager.INSTANCE.GetItem(3);
            Debug.Log("ID : " + item.ID + " | 이름 : " + item.NAME + " | 데미지 : " + item.DAMAGE + " | 장탄수 : " + item.MAGAZINE
                + " | 발사총알수 : " + item.BULLET + " | 장전속도 : " + item.RELOAD + " | 탄속도 : " +
                item.VELOCITY + " | 연사력 : " + item.SHOTDELAY + " | 사정거리 : " + item.RANGE + " | 산탄도 : " +
                item.BUCKSHOT + " | 연사가능성 : " + item.AUTO);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            ItemInfo item = ItemManager.INSTANCE.GetItem(4);
            Debug.Log("ID : " + item.ID + " | 이름 : " + item.NAME + " | 데미지 : " + item.DAMAGE + " | 장탄수 : " + item.MAGAZINE
                + " | 발사총알수 : " + item.BULLET + " | 장전속도 : " + item.RELOAD + " | 탄속도 : " +
                item.VELOCITY + " | 연사력 : " + item.SHOTDELAY + " | 사정거리 : " + item.RANGE + " | 산탄도 : " +
                item.BUCKSHOT + " | 연사가능성 : " + item.AUTO);
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            ItemInfo item = ItemManager.INSTANCE.GetItem(5);
            Debug.Log("ID : " + item.ID + " | 이름 : " + item.NAME + " | 데미지 : " + item.DAMAGE + " | 장탄수 : " + item.MAGAZINE
                + " | 발사총알수 : " + item.BULLET + " | 장전속도 : " + item.RELOAD + " | 탄속도 : " +
                item.VELOCITY + " | 연사력 : " + item.SHOTDELAY + " | 사정거리 : " + item.RANGE + " | 산탄도 : " +
                item.BUCKSHOT + " | 연사가능성 : " + item.AUTO);
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            ItemInfo item = ItemManager.INSTANCE.GetItem(6);
            Debug.Log("ID : " + item.ID + " | 이름 : " + item.NAME + " | 데미지 : " + item.DAMAGE + " | 장탄수 : " + item.MAGAZINE
                + " | 발사총알수 : " + item.BULLET + " | 장전속도 : " + item.RELOAD + " | 탄속도 : " +
                item.VELOCITY + " | 연사력 : " + item.SHOTDELAY + " | 사정거리 : " + item.RANGE + " | 산탄도 : " +
                item.BUCKSHOT + " | 연사가능성 : " + item.AUTO);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(ItemManager.INSTANCE.GetItemsCount());
        }
    }
}
    


