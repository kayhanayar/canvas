using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartikulKod : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 hizVectoru;
    public byte saydamlikAzaltmaDegeri;
    SpriteRenderer spriterenderer;
    Color32 renk;
    float gecenZaman = 0.0f;
    void Start()
    {
        saydamlikAzaltmaDegeri = 25;
        spriterenderer = GetComponent<SpriteRenderer>();
        renk = spriterenderer.color;
    }

    // Update is called once per frame
    void Update()
    {

        if(renk.a> 0)
        {
            
            renk.a = (byte)Mathf.Lerp(155, 0, gecenZaman);
            hizVectoru.x = Mathf.Lerp(hizVectoru.x, 0, gecenZaman);
            hizVectoru.y = Mathf.Lerp(hizVectoru.y, 0, gecenZaman);
            gecenZaman += Time.deltaTime;
            spriterenderer.color = renk;
        }
        else
        {
            Destroy(gameObject);
        }
        transform.position += hizVectoru*Time.deltaTime;

    }
}
