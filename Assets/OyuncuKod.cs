using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuKod : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Vector2 hizVectoru;
    float hizCarpani;
    [SerializeField] GameObject mermiSablon;
    Transform burunTopu;
    Transform solTop;
    Transform sagTop;

    float mermiAtmaSuresi;
    float mermiSayacSuresi;
    enum AtesModu
    {
        Tek,
        Cift
    }
    AtesModu atesModu =AtesModu.Tek;
    void Start()
    {
        hizCarpani = 10.0f;
        rb= GetComponent<Rigidbody2D>();
        solTop = GameObject.Find("SolTop").transform;
        sagTop = GameObject.Find("SagTop").transform;
        burunTopu = GameObject.Find("BurunTopu").transform;
        mermiAtmaSuresi = 1.0f;
        mermiSayacSuresi = 0.0f;

    }
    void AtesEt()
    {
        bool tusaBasildimi = Input.GetKeyDown(KeyCode.Space);
        bool zamanDoldumu = mermiAtmaSuresi <= mermiSayacSuresi;
        if (tusaBasildimi&&zamanDoldumu)
        {
            if(atesModu== AtesModu.Tek)
            {
                var mermi = Instantiate(mermiSablon);
                mermi.transform.position = burunTopu.position;
            }
            else
            {

            }
            mermiSayacSuresi=0;
        }
        mermiSayacSuresi += Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        AtesEt();
        float x = Input.GetAxis("Horizontal");


        hizVectoru.x = x * hizCarpani;

        rb.velocity = hizVectoru;
    }
}
