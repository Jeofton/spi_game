using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    
    [SerializeField] private Transform pointA, pointB, pointAux;
    [SerializeField] private float speed;
    [SerializeField] private float speedRotate;
    private void Start()
    {
        transform.position = pointA.position;
    }

    private void Update()
    {
        transform.Rotate(0, 0, speedRotate * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, pointAux.position, speed * Time.deltaTime);

        if (transform.position.y <= pointB.position.y)
        {
            pointAux.position = pointA.position;
        }

        if (transform.position.y >= pointA.position.y)
        {
            pointAux.position = pointB.position;
        }
    }
}
