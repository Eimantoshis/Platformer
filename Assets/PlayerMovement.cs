using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float Move;
    bool facingRight = true;
    public float jump;
    public bool isJumping;


    public GameObject spawn;//public kad galetu is flagCode paimti
    private Rigidbody2D rb;

    public Animator animator;

    public bool IsReg;
    public bool IsHeav;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        ///Animations
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        

        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);
        

        if (rb.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (rb.velocity.x <0 && facingRight)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && isJumping == false /*&& Time.time <WasGroundedAt + 0.05f*/)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
        }
    }
   
    public void Respawn()
    {
        gameObject.transform.position = spawn.transform.position;
        if (IsReg)
        {
            animator.Play("Player_Change");
            animator.SetBool("IsChanging", true);
            WaitForCancelation();
        }
        if (IsHeav)
        {
            animator.Play("HPlayer_Change");
            animator.SetBool("IsChanging", true);
            WaitForCancelation();
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
    public void WaitForCancelation()
    {
        Invoke("CancelAniamtion", 1);
    }

    private void CancelAniamtion()
    {
        animator.SetBool("IsChanging", false);
    }


}
