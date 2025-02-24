using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter_kontrol : MonoBehaviour
{
    Rigidbody rigi;
    float ziplama_gucu = 5.0f;
    float kosma_hizi = 5.0f;
    float hiz_arttir = 0.5f;
    float max_hiz = 10.0f;
    float mevcut_hiz;
    float timer;
    bool sag;
    bool sol;
    bool zipladi = false;
    public GameObject toz;
    Transform yol_1;
    Transform yol_2;
    Animator anim;
    yonetici yonet;
   public  bool miknatis_alindi = false;
    public GameObject oyun_bitti_paneli;

    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        yol_1 = GameObject.Find("yol_1").transform;
        yol_2 = GameObject.Find("yol_2").transform;
        yonet = GameObject.Find("yonetici").GetComponent<yonetici>();
        mevcut_hiz = kosma_hizi;
        timer = 0f;
    }
    private void OnCollisionStay(Collision collision)
    {
        zipladi = false;
        if (toz.activeSelf == false)
        {
            toz.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        zipladi = true;
        if (toz.activeSelf == true)
        {

            toz.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="engel")
        {
            oyun_bitti_paneli.SetActive(true);
            Time.timeScale = 0.0F;
        }
    }
    // 3.8 ile 0.5
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="yol_1")
        {
            yol_2.position = new Vector3(yol_2.position.x, yol_2.position.y, yol_1.position.z + 16.39f);
        }
        if (other.gameObject.name == "yol_2")
        {
            yol_1.position = new Vector3(yol_1.position.x, yol_1.position.y, yol_2.position.z + 16.39f);
        }
        if(other.gameObject.tag == "altin")
        {
            other.gameObject.SetActive(false);
            yonet.puan_arttir(10);

        }
        if (other.gameObject.tag == "miknatis")
        {
            other.gameObject.SetActive(false);
            miknatis_alindi = true;
            Invoke("miknatis_iptal", 10.0f);
        }
    }
    void miknatis_iptal()
    {
        miknatis_alindi = false;
    }
    void hiz_art()
    {
        if (mevcut_hiz < max_hiz)
        {
            mevcut_hiz += hiz_arttir;
            if (mevcut_hiz > max_hiz) 
            {
                mevcut_hiz = max_hiz;
            }
        }
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 20f)
        {
            timer = 0f;  
            hiz_art();  
        }
        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);
            if(parmak.deltaPosition.x > 50.0f)
            {
                sag = false;
                sol = true;
            }
            if(parmak.deltaPosition.x < -50f)
            {
                sag = true;
                sol = false;
            }
        }
        if (sag == true) {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0.5f, transform.position.y, transform.position.z), 10.0f * Time.deltaTime);        
        }
        if (sol == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(3.8f, transform.position.y, transform.position.z), 10.0f * Time.deltaTime);
        }
        transform.Translate(0,0,10.0f*Time.deltaTime);
    }
    public void zipla()
    {
        if (zipladi == false)
        {
            anim.SetTrigger("zipla");
            rigi.velocity = Vector3.zero;
            rigi.velocity = Vector3.up * ziplama_gucu;
        }
    }
}
