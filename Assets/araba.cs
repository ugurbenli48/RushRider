using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class araba : MonoBehaviour
{
    float deger = 2.0f;
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Translate(0,0,deger*Time.deltaTime);
    }
}
