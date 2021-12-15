using System.Collections;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator anim;
    private PlayerController playerController;
    private SpriteRenderer sprite;

    void Awake() {

        if (sprite == null) sprite = GetComponent<SpriteRenderer>();
        if (anim == null) anim = GetComponent<Animator>();
        if (playerController == null) playerController = GetComponentInParent<PlayerController>();
                 
    }    

    void Update() {
        anim.SetFloat("Horizontal", Mathf.Abs(playerController.Horizontal));

        anim.SetFloat("VelocityY", playerController.VelocityY);

        anim.SetBool("IsGround", playerController.IsGround);

        Atack();
        Flip();

    }

    void Atack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Atack");
        }
    }

    void Flip()
    {
        if (playerController.Horizontal > 0 && sprite.flipX)
        {
            sprite.flipX = false;
        }
        if (playerController.Horizontal < 0 && !sprite.flipX)
        {
            sprite.flipX = true;
        }
    }


    public void StartBlink()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        for(int i = 1; i <= 5; i++)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
            yield return new WaitForSeconds(0.1f);
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
            yield return new WaitForSeconds(0.1f);
            playerController.damage = false;
        }
    }

}
