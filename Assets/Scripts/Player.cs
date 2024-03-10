using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform chGround;
    [SerializeField] private LayerMask chLayer;
    [SerializeField] private Animator anim;
    [SerializeField] private TrailRenderer _trailRenderer;


    private SpriteRenderer sprite;

    [SerializeField] Transform bullet;
    [SerializeField] SpriteRenderer bulletspr;

    private float inputX;
    private float speed = 7f;
    private float jmpPower = 5.5f;
    private bool isFacingRight = true;


  private MovementState state = 0;



    private enum MovementState
    {
        idle, running,jumping,falling,dashing
    }



    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {





    
        inputLogic();

        animLogic();


        //Flip();
    }





    private void inputLogic()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jmpPower);
        }


    }



    private void animLogic()
    {
        MovementState state;

        if (inputX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
            bullet.transform.Rotate(0f, 180f, 0f);
        }
        else if (inputX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
            bulletspr.flipX = true;

        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);

    }

    private void FixedUpdate()
    {

    }

   






    private bool isGround()
    {
        return Physics2D.OverlapCircle(chGround.position, 0.2f, chLayer);
    }



    //bugada
    private void Flip()
    {

        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);

        
    }

}
