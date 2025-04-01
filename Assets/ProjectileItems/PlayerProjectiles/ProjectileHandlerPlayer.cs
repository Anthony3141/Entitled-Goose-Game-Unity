using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileHandlerPlayer : MonoBehaviour
{
    public int hp = 0;
    public float speed = 0; // pixels per second
    public bool interactsWithProjectiles = false;

    void Start()
    {

    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        
        //make sure it doesn't go off screen
        if (transform.position.x > 15 || hp <= 0) { 
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectile") && interactsWithProjectiles)
        {
            collision.gameObject.GetComponent<ProjectileHandlerEnemy>().hp -= hp;
            hp = -collision.gameObject.GetComponent<ProjectileHandlerEnemy>().hp;
        }

        if (collision.gameObject.CompareTag("EnemyPerson"))
        {
            
        }

    }
}
