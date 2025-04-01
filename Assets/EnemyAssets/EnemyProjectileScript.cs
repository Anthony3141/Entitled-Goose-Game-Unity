using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour {
    public bool projectileCollision;
    public float speed;
    public int health;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
     //   Debug.Log("speed enemy proj: " + speed);
        if (health <= 0)
        {
            Debug.Log("enemy is dying");
            death();
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            Debug.Log("hitting border");
            Destroy(this.gameObject, .01f);
        }
        else if (other.CompareTag("Player"))
        {
            PlayerBehaviour playerScript = other.GetComponent<PlayerBehaviour>();
            playerScript.TakeDamage(damage);
            death();


        }
        else if (other.CompareTag("shield")){
            shieldScript shieldScript = other.GetComponent<shieldScript>();
            Debug.Log("hit a sheild");
            if(shieldScript.isReflect == true)
            {
                Debug.Log("reflecting by sheild");
                speed = -speed;

                shieldScript.TakeDamage(damage);
            }
            else
            {
                Debug.Log("NANI???");
                shieldScript.TakeDamage(damage);
                death();

            }
     
        }
        else if (other.CompareTag("PlayerProjectile"))
        {
 
        }
    }
    public void death()
    {
        Debug.Log("death function");
        speed = 0;

        PlayExplodeAnimation();
        Destroy(this.gameObject, .01f);
    }

    public void PlayCollideAnimation()
    {

    }
    public void PlayExplodeAnimation()
    {

    }
}
