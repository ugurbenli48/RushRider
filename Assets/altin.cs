using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altin : MonoBehaviour
{
    Transform cocuk;
    karakter_kontrol kontrol;
    void Start()
    {
        cocuk = GameObject.Find("cocuk").transform;
        kontrol = GameObject.Find("cocuk").GetComponent<karakter_kontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        float mesafe = Vector3.Distance(transform.position, cocuk.position);
        if (kontrol.miknatis_alindi == true)
        {
            
            if (mesafe <= 5.0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, cocuk.position, 12.0f * Time.deltaTime);
            }
        }
        if (transform.position.z < (cocuk.position.z - 5.0f))
        {
            gameObject.SetActive(false);
        }
    }
}
