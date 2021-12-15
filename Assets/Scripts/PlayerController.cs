using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float speed;

    private float horizontal;

    public float Horizontal => this.horizontal;

    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGround;
    public bool IsGround => isGround;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;

    [SerializeField] private Transform initialPoint;


    [SerializeField]
    private GameObject prefabLaser;
    [SerializeField]
    private Transform laserPosition;

    private PlayerAnimationController playerAnimation;

    public bool damage = false;

    private LifeController lifeController;

    private Rigidbody2D rb;

    public float VelocityY => rb.velocity.y;

    private void Awake(){
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (playerAnimation == null) playerAnimation = GetComponentInChildren<PlayerAnimationController>();
        if (lifeController == null) lifeController = GetComponent<LifeController>();
    }

    private void Update() {
        if (!damage) horizontal = Input.GetAxisRaw("Horizontal");

        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundMask);

        Jump();

        if (lifeController.IsDead())
        {
            transform.position = initialPoint.position;
        }


        LaserShoot();

    }

    private void FixedUpdate() {
        Vector2 velocity = new Vector2(horizontal*speed*Time.fixedDeltaTime, rb.velocity.y);
        if (damage) velocity = Vector2.zero;
        rb.velocity = velocity;

    }

    void Jump()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            AudioController.instance.PlayAudioJump();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Saw") && !damage)
        {
            damage = true;

            lifeController.LifeLost(1);

            if (collision.transform.position.x > transform.position.x)
            {
                rb.AddForce(new Vector2(-2500,rb.velocity.y));
            }
            else
            {
                rb.AddForce(new Vector2(2500, rb.velocity.y));
            }
            
            playerAnimation.StartBlink();
        }

        if (collision.gameObject.CompareTag("Spikes") || collision.gameObject.CompareTag("Acid") && !damage){

            damage = true;
            lifeController.LifeLost(3);
            playerAnimation.StartBlink();

        }

    }


    void LaserShoot()
    {   
        
        if (Input.GetMouseButtonDown(0))
        {
            GameObject prefabTemp = Instantiate(this.prefabLaser, this.laserPosition.position, this.transform.rotation);
            prefabTemp.GetComponent<Rigidbody2D>().AddForce(new Vector2(750, 0));
        }
    }
}
