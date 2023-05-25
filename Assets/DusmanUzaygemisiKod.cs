using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanUzaygemisiKod : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 hizVectoru;
    float hareketCarpani;
    [SerializeField] GameObject mermiSablon;
    [SerializeField]Transform solTop;
    [SerializeField]Transform sagTop;
    [SerializeField] Transform govde;
    [SerializeField] Transform burun;
    [SerializeField] GameObject dusmanMermiSablon;
    PartikulUretici partikulUretici;
    float mermiAtmaSuresi = 2.0f;
    float mermiAtmaSayac = 0.0f;
    float dikeyHareketZamani;
    float dikeyGecenZaman;
    bool dikeyHareketAktifmi;
    // Start is called before the first frame update
    Vector2 yatayHiz;
    Vector2 dikeyHiz;
    bool siradakiTop=false;
    void Start()
    {

        dikeyHareketAktifmi = true;
        dikeyHareketZamani = 2.0f;
        dikeyGecenZaman = 0.0f;
        hareketCarpani = 2.00f;
        partikulUretici = GameObject.Find("PartikulUretici").GetComponent<PartikulUretici>(); ;
        rb = GetComponent<Rigidbody2D>();
        yatayHiz = new Vector2(hareketCarpani*2, 0.0f);
        dikeyHiz = new Vector2(0.0f, -hareketCarpani);
        rb.velocity = dikeyHiz;
        Physics2D.IgnoreLayerCollision(6, 6);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name=="SolSinir"||
            collision.collider.name=="SagSinir")
        {
            dikeyGecenZaman = 0.0f;
            dikeyHareketAktifmi = true;
            rb.velocity= dikeyHiz;
        }
        if(collision.collider.CompareTag("Mermi"))
        {
            
            Destroy(collision.collider.gameObject);
            transform.DetachChildren();
            solTop.gameObject.AddComponent<DusmanParcasiKod>().YonAta(-1,-1);
            sagTop.gameObject.AddComponent<DusmanParcasiKod>().YonAta(1, -1); ;
            govde.gameObject.AddComponent<DusmanParcasiKod>().YonAta(0, 1); ;
            burun.gameObject.AddComponent<DusmanParcasiKod>().YonAta(0, -1); ;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(dikeyHareketAktifmi)
        {
            if(dikeyGecenZaman>dikeyHareketZamani)
            {
                dikeyGecenZaman = 0.0f;
                dikeyHareketAktifmi = false;
                rb.velocity = yatayHiz;
                yatayHiz = -yatayHiz;
            }
            dikeyGecenZaman += Time.deltaTime;
        }
        else
        {
            if(mermiAtmaSuresi<mermiAtmaSayac)
            {
                var mermi = Instantiate(dusmanMermiSablon);
                if (siradakiTop == false)
                {
                    mermi.transform.position = solTop.position;
                }
                else
                    mermi.transform.position = sagTop.position;
                siradakiTop = !siradakiTop;
                mermiAtmaSayac = 0.0f;
            }


            mermiAtmaSayac += Time.deltaTime;

        }

    }
}
