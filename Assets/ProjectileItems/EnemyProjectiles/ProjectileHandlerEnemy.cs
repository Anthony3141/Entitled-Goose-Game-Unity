using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandlerEnemy : MonoBehaviour
{
    //external inputs

    public int hp = 0;
    public int speed = 0; // pixels per second
    public int rotSpeed = 0; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * -1, 0, 0);
        
        //make sure it doesn't go off screen
        if (transform.position.x < -15 || hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerPerson"))
        {
            Debug.Log("player has been hit");
        }
    }
}
