using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    [SerializeField]
    private float speed;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    
    void Start()
    {
        Destroy(this.gameObject, 1);
        
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(speed * Time.deltaTime, 0));
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    Destroy(this.gameObject);
    //}
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
