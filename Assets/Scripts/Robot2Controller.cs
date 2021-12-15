using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot2Controller : MonoBehaviour
{
    [SerializeField] private Transform pointA, pointB, pointAux;

    public Transform PointA => this.pointB;
    public Transform PointB => this.pointB;
    public Transform PointAux => this.pointAux;

    [SerializeField] private float speed;


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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
