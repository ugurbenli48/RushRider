using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UIElements;

public class donmek : MonoBehaviour
{
    string isim;
    float deger = 300f;
    Transform x;
    void Start()
    {
        isim = gameObject.tag;
    }

    void Update()
    { 
        if(isim =="miknatis")
        {
            transform.Rotate(0, deger * Time.deltaTime, 0, Space.World);
        }
        if (isim == "altin")
        {
            transform.Rotate(0, deger*Time.deltaTime, 0,Space.World);
        }
    }
}
