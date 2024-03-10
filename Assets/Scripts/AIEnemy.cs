using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AIEnemy : MonoBehaviour
{
    public GameObject player;

    public float speed;

    private float distance;




    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        Vector2 dir = player.transform.position - transform.position;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (distance < 4)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }

}
