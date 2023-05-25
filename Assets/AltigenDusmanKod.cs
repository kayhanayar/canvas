using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltigenDusmanKod : MonoBehaviour
{
    // Merhabalar burası değişim kısmı
    float omur;
    float gecenSure;
    bool yokoluyormu;
    SpriteRenderer renderer;
    Color32 renk;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renk = renderer.color;
        omur = 4.0f;
        gecenSure = 0.0f;
        yokoluyormu = false;
    }
    void oldur()
    {
        

        Color32 renk = renderer.color;
        renk.a = (byte)Mathf.Lerp(255,0, gecenSure*0.5f);
        renderer.color = renk;
      
        if(renk.a<=0)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(yokoluyormu)
            oldur();
        if(omur<gecenSure)
        {
            yokoluyormu=true;
            
            gecenSure = 0.0f;
        }
        transform.Rotate(0, 0, 0.5f);

        gecenSure += Time.deltaTime;
    }
}
