using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanUretici : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] DusmanlarSablonlari;
    [SerializeField] Transform[] DusmanUretmeNoktalari;
    [SerializeField] float DusmanUretmeAraligi ;
    [SerializeField] Transform DusmanUretmeNoktasi;
   
    float dusmanUretmeSayaci;
    void Start()
    {
        
    }
    void DusmanUret()
    {
        int dusmanSirasi = Random.Range(0, DusmanlarSablonlari.Length);

        var dusman = Instantiate(DusmanlarSablonlari[dusmanSirasi]);

        int dusmanUretmeIndeksi = Random.Range(0, DusmanUretmeNoktalari.Length);
        dusman.transform.position = DusmanUretmeNoktalari[dusmanUretmeIndeksi].position;
    }
    // Update is called once per frame
    void Update()
    {
        if(dusmanUretmeSayaci>=DusmanUretmeAraligi)
        {
            DusmanUret();

            dusmanUretmeSayaci = 0;
        }
        dusmanUretmeSayaci += Time.deltaTime;
    }
}
