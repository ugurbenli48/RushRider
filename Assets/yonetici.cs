using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class yonetici : MonoBehaviour
{
    public GameObject altin;
    public GameObject miknatis;
    public GameObject araba;
    public GameObject kutuk;
    public GameObject tas;
    List<GameObject> altinlar;
    List<GameObject> digerleri;
    List<GameObject> miknatislar;
    Transform cocuk;
    public TMPro.TextMeshProUGUI puan_txt;
    public GameObject oyunu_durdur_pnl;
    int puan = 0;
    void Start()
    {
        altinlar = new List<GameObject>();
        digerleri = new List<GameObject>();
        miknatislar = new List<GameObject>();
        cocuk = GameObject.Find("cocuk").transform;
        uretme(altin, 10, altinlar);
        uretme(miknatis, 3, miknatislar);
        uretme(tas, 3, digerleri);
        uretme(araba, 3, digerleri);
        uretme(kutuk, 3, digerleri);
        InvokeRepeating("miknatis_uret", 2.5f, 15.0f);
        InvokeRepeating("engel_uret", 1.5f, 3.0f);
        InvokeRepeating("altin_uret", 0.0f, 1.0f);
        puan_txt.text= "SKOR " + puan.ToString();

    }

    private void uretme(GameObject nesne, int miktar, List<GameObject> liste)
    {
        for (int i = 0; i < miktar; i++)
        {
            GameObject yeni_nesne = Instantiate(nesne);
            yeni_nesne.SetActive(false);
            liste.Add(yeni_nesne);
        }
    }
    public void puan_arttir(int deger)
    {
        puan += deger;
        puan_txt.text = "SKOR " +puan.ToString();
    }
    void altin_uret()
    {
        foreach (GameObject altin in altinlar)
        {
            if (altin.activeSelf == false)
            {
                altin.SetActive(true);
                int rastgele = Random.Range(0, 2);
                if (rastgele == 0)
                {
                    altin.transform.position = new Vector3(0.5f, 0.14f, cocuk.position.z + 10.0f); ;
                }
                if (rastgele == 1)
                {
                    altin.transform.position = new Vector3(3.8f, 0.14f, cocuk.position.z + 10.0f); ;
                }

                return;
            }
        }
    }
    void engel_uret()
    {
        int rast = Random.Range(0, digerleri.Count);
        if (digerleri[rast].activeSelf == false)
        {
            digerleri[rast].SetActive(true);
            int rastgele = Random.Range(0, 2);
            if (rastgele == 0)
            {
                digerleri[rast].transform.position = new Vector3(0.5f, -0.6f, cocuk.position.z + 10.0f); ;
            }
            if (rastgele == 1)
            {
                digerleri[rast].transform.position = new Vector3(3.8f, -0.6f, cocuk.position.z + 10.0f); ;
            }
            else
            {
                foreach (GameObject nesne in digerleri)
                {
                    if (nesne.activeSelf == false)
                    {
                        nesne.SetActive(true);
                        int rastgele_2 = Random.Range(0, 2);
                        if (rastgele_2 == 0)
                        {
                            nesne.transform.position = new Vector3(0.5f, -0.6f, cocuk.position.z + 10.0f); ;
                        }
                        if (rastgele_2 == 1)
                        {
                            nesne.transform.position = new Vector3(3.8f, -0.6f, cocuk.position.z + 10.0f); ;
                        }

                        return;
                    }
                }
            }
        }
    }
    public void tekrar_oyna()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
        Time.timeScale = 1.0f;
    }
    public void devam_et()
    {
        oyunu_durdur_pnl.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void oyunu_durdur()
    {
        oyunu_durdur_pnl.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void oyundan_cik()
    {
        Application.Quit();
    }
    void miknatis_uret()
    {
        int ras = Random.Range(0, miknatislar.Count);
        if (miknatislar[ras].activeSelf == false)
        {
            miknatislar[ras].SetActive(true);
            int rastgele = Random.Range(0, 2);
            if (rastgele == 0)
            {
                miknatislar[ras].transform.position = new Vector3(0.5f, -0.6f, cocuk.position.z + 10.0f); ;
            }
            if (rastgele == 1)
            {
                miknatislar[ras].transform.position = new Vector3(3.8f, -0.6f, cocuk.position.z + 10.0f); ;
            }
            if (cocuk.gameObject.GetComponent<karakter_kontrol>().miknatis_alindi == true)
            {
                miknatislar[ras].SetActive(false);
            }
        }
        else
        {
            foreach (GameObject nes in digerleri)
            {
                if (nes.activeSelf == false)
                {
                    nes.SetActive(true);
                    int rastgele_2 = Random.Range(0, 2);
                    if (rastgele_2 == 0)
                    {
                        nes.transform.position = new Vector3(0.5f, -0.6f, cocuk.position.z + 10.0f); ;
                    }
                    if (rastgele_2 == 1)
                    {
                        nes.transform.position = new Vector3(3.8f, -0.6f, cocuk.position.z + 10.0f); ;
                    }
                    if (cocuk.gameObject.GetComponent<karakter_kontrol>().miknatis_alindi == true)
                    {
                        nes.SetActive(false);
                    }

                }
            }
        }
    }
   
    void Update()
    {

    }
}
