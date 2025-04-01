using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shieldScript : MonoBehaviour {
    public int health;
    public GameObject shieldBar;
    public Slider miniHealthBar;
    public Animator animator;

    public bool isReflect;

    // Start is called before the first frame update
    void Start()
    {
        //switch shield's health bar back on if it was turned off
        shieldBar.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.D))
        {
            TakeDamage(25);
        }
        */
        miniHealthBar.value = health;
    }

    public void TakeDamage (int damage){
        //subtract damage from current health
        health -= damage;
        //play hit animation
        animator.SetTrigger("hit");
        //check if dead
        if (health <= 0){
            Dies();
        }
    }

    private void Dies(){
        //delete shield's health bar
        shieldBar.SetActive(false);
        //play death animation
        animator.SetTrigger("dies");
    }

    //on animation trigger
    private void DestroyThis(){
        //delete game object
        Destroy(gameObject);
    }

    public void setHealth(int hp){
        health = hp;
    }
}
