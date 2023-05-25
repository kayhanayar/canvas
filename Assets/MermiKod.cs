using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiKod : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float hizCarpani;
    Rigidbody2D rb;
    Vector2 hiz;
    GameObject oyuncu;
    void Start()
    {
        hiz = new Vector2(0.0f,hizCarpani);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = hiz;
        var oyuncuCollider = GameObject.Find("Oyuncu").GetComponent<PolygonCollider2D>();
        Physics2D.IgnoreCollision(GetComponent<PolygonCollider2D>(),oyuncuCollider);
    }
    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
