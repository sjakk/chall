using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int life = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Life")){
            Destroy(collision.gameObject);
            life++;
            Debug.Log("Life:  " + life);
        }
    }


}
