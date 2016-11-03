using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System.Text;
using System;

public class xmlparse : MonoBehaviour {
    string xml_file_name = "item_gun.xml";
    void Start() {
        StartCoroutine("process");
    }
    IEnumerator process() {
        string path = string.Empty;
#if (UNITY_EDITOR || UNITY_STANDALONE_WIN)
        path += ("file:///");
         path += (Application.streamingAssetsPath + "/" + xml_file_name);
#elif UNITY_ANDROID
        strPath =  "jar:file://" + Application.dataPath + "!/assets/" + m_strName;
#endif
        WWW www = new WWW(path);
        yield return www;
        parse(www.text);
    }
    void parse(string file)
    {
        StringReader stringreader = new StringReader(file);

        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(stringreader.ReadToEnd());
        XmlNodeList xmlnodelist = null;
        try
        {
            xmldoc.LoadXml(stringreader.ReadToEnd());
        }
        catch
        {
            xmldoc.LoadXml(file);
        }

        xmlnodelist = xmldoc.SelectNodes("Gun");
        foreach (XmlNode node in xmlnodelist)
        {
            if (node.Name.Equals("Gun") || node.HasChildNodes)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    ItemInfo item = new ItemInfo();
                    item.ID = int.Parse(child.Attributes.GetNamedItem("id").Value);
                    item.NAME = child.Attributes.GetNamedItem("name").Value;
                    item.DAMAGE = int.Parse(child.Attributes.GetNamedItem("damage").Value);
                    item.MAGAZINE = int.Parse(child.Attributes.GetNamedItem("magazine").Value);
                    item.BULLET = int.Parse(child.Attributes.GetNamedItem("bullet").Value);
                    item.RELOAD = float.Parse(child.Attributes.GetNamedItem("reload").Value);
                    item.VELOCITY = int.Parse(child.Attributes.GetNamedItem("velocity").Value);
                    item.SHOTDELAY = float.Parse(child.Attributes.GetNamedItem("shotdelay").Value);
                    item.RANGE = int.Parse(child.Attributes.GetNamedItem("range").Value);
                    item.BUCKSHOT = int.Parse(child.Attributes.GetNamedItem("buckshot").Value);
                    item.AUTO=bool.Parse(child.Attributes.GetNamedItem("auto").Value);
                    ItemManager.INSTANCE.AddItem(item);
                }
            }
        } 
    }
}
