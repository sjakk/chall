using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform chGround;
    [SerializeField] private LayerMask chLayer;
    [SerializeField] private Animator anim;

    private float inputX;
    private float speed = 8f;
    private float jmpPower = 16f;
    private bool isFacingRight = true;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        inputLogic();

        animLogic();


        Flip();
    }





    private void inputLogic()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jmpPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

    }



    private void animLogic()
    {
        if (inputX > 0f || inputX < 0f)
        {
            anim.SetBool("running", true);
        }
        else if (inputX == 0f)
        {
            anim.SetBool("running", false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputX * speed,rb.velocity.y);
    }


    private bool isGround()
    {
        return Physics2D.OverlapCircle(chGround.position, 0.2f, chLayer);
    }


    private void Flip()
    {
        if(!isFacingRight && inputX > 0f || isFacingRight && inputX < 0f) {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
