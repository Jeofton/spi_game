using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot3Controler : MonoBehaviour
{
    [SerializeField] private Transform pointA, pointB, pointAux;
    [SerializeField] private float speed;
    private SpriteRenderer sprite;

    public bool damage = false;

    private void Start()
    {
        transform.position = pointA.position;
    }

       
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointAux.position, speed * Time.deltaTime);


        if (transform.position.x >= pointB.position.x)
        {
            pointAux.position = pointA.position;
        }

        if (transform.position.x <= pointA.position.x)
        {
            pointAux.position = pointB.position;
        }

        Flip();
        
    }
        

    void Flip() {

        if (sprite == null) sprite = GetComponent<SpriteRenderer>();

        if (transform.position == pointA.position && !sprite.flipX)
        {
            sprite.flipX = true;
        }
        if (transform.position == pointB.position && sprite.flipX)
        {
            sprite.flipX = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

}
