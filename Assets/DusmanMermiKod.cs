using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanMermiKod : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.0f, -10.0f);
        Physics2D.IgnoreLayerCollision(6, 6);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, 1.0f);
    }
}
