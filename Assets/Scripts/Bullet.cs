using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{


    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject hitEffect;


    // Start is called before the first frame update
    void Start()
    {
        
        rb.velocity = transform.right * speed;

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        
        if(enemy != null)
        {
            enemy.TakeDamage(40);
        }

        Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
