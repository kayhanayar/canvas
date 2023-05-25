using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class YuvarlakDusman : MonoBehaviour
{
    // Start is called before the first frame update
    public float hareketAcisi;
    Vector2 hizVectoru;
     float hareketCarpani;
    PartikulUretici partikulUretici;
   

    enum DusmanDurumu
    {
        Buyuk,
        Kucuk
    }
    DusmanDurumu durum;
    void Awake()
    {
        hareketAcisi= Random.Range(70.0f, 87.0f);
        if(Random.Range(0,2)==0)
        {
            hareketAcisi = -hareketAcisi;
        }
        hareketCarpani = 2.0f;
        hizAyarla();
        durum = DusmanDurumu.Buyuk;
        partikulUretici = GameObject.Find("PartikulUretici").GetComponent<PartikulUretici>(); ;
       
    }
    void hizAyarla()
    {
        hizVectoru.x = hareketCarpani * Mathf.Sin(Mathf.Deg2Rad * hareketAcisi);
        hizVectoru.y = -hareketCarpani;
        GetComponent<Rigidbody2D>().velocity = hizVectoru;
    }
    void KucukleriOlustur()
    {
        var d1 = Instantiate(gameObject);
        var d2 = Instantiate(gameObject);
        var pos = d1.transform.position;
        d2.transform.position = pos-new Vector3(0.6f,0.0f,0.0f);
        d1.transform.localScale=new Vector3 (0.9f, 0.9f, 0.9f);
        d2.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        d1.GetComponent<YuvarlakDusman>().hareketAcisi = -Mathf.Abs(d1.GetComponent<YuvarlakDusman>().hareketAcisi);
        d2.GetComponent<YuvarlakDusman>().hareketAcisi = -d1.GetComponent<YuvarlakDusman>().hareketAcisi;
        
        d1.GetComponent<YuvarlakDusman>().durum = DusmanDurumu.Kucuk;
        d2.GetComponent<YuvarlakDusman>().durum = DusmanDurumu.Kucuk;
        d1.GetComponent<YuvarlakDusman>().hizAyarla();
        d2.GetComponent<YuvarlakDusman>().hizAyarla();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Mermi"))
        {
            if (durum == DusmanDurumu.Buyuk)
            {
                KucukleriOlustur();

            }
            partikulUretici.PartikulUret(transform.position);
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
        else if (collision.collider.CompareTag("Oyuncu"))
        {

                ContactPoint2D[] carpismaNoktalari = new ContactPoint2D[10];
                int adet = collision.GetContacts(carpismaNoktalari);
                Vector2 ortalamaKonum = new Vector2(0.0f, 0.0f);
                
                for (int i = 0; i < adet; i++)
                {
                    ortalamaKonum += carpismaNoktalari[i].point;
                }
                ortalamaKonum /= adet;
                Vector3 konum = ortalamaKonum;
                Destroy(gameObject);
                partikulUretici.PartikulUret(konum);
                

        }
        else
        {
            hareketAcisi = -hareketAcisi;
            
        }
        hizAyarla();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    // Update is called once per frame

    void Update()
    {
        Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position + hizVectoru,Color.green);
        
    }
}
