using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartikulUretici : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject partikulSablon;
    [SerializeField] float hizCarpani;

    void Start()
    {
        
    }
    public void PartikulUret(Vector3 konum)
    {
        int aciArtisi = 30;
        Vector3 hizVector = new Vector3(0.0f, 0.0f, 0.0f);
        for (int aci = 0; aci <= 360; aci += aciArtisi)
        {
            var partikul = Instantiate(partikulSablon);

            hizVector.x = hizCarpani * Mathf.Cos(aci);
            hizVector.y = hizCarpani * Mathf.Sin(aci);
            partikul.GetComponent<PartikulKod>().hizVectoru = hizVector;
            partikul.transform.position = konum;

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
