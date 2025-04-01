using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    //variables
    public GameObject player;
    private PlayerBehaviour playerScript;
    public int speed = 1;
    public int damage;
    public int health;

    void Start(){
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update(){
        //move left by 1 * speed * time
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        //if outside screen, destroy
        if (transform.position.x < -10){
            DestroyThis();
        }
    }

    private void DestroyThis(){
        Destroy(gameObject);
    }

    public void setDamage(int dmg){
        damage = dmg;
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            Debug.Log("trigged");
            playerScript.TakeDamage(damage);
            DestroyThis();
        }
        else if (collision.CompareTag("shield")){
            shieldScript shieldScript = collision.GetComponent<shieldScript>();
            shieldScript.TakeDamage(damage);
            DestroyThis();
        }
    }
}
