using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanParcasiKod : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 hiz;
    public int yon=1;
    float yokEtmeZamani= 2.0f;
    float gecenZaman = 0.0f;
    SpriteRenderer spriteRenderer;
    Color32 renk;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        renk = spriteRenderer.color;
    }
    public void YonAta(int xyon,int yyon/*x yönü*/)
    {
        hiz.x = 3.0f * xyon;
        hiz.y = 3.0f* yyon;
    }
    // Update is called once per frame
    void Update()
    {
        if (gecenZaman < yokEtmeZamani)
        {
            transform.position += hiz * Time.deltaTime;
           
            renk.a = (byte)Mathf.Lerp(255, 0, gecenZaman*0.5f);
            spriteRenderer.color = renk;
            gecenZaman += Time.deltaTime;
            transform.Rotate(0.0f, 0.0f, 2.0f);
            
        }
        else
            Destroy(gameObject);

    }
}
