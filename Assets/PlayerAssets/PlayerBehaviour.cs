using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {
    //references
    [Header("Game Objects")]
    public Slider healthBar;
    public GameObject fill;
    public GameObject[] shields;
    public Animator resetScreenAnimator;

    //current variables
    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Animation")]
    public Animator animator;

    public GameObject SceneManager;

    // Start is called before the first frame update
    void Start(){
        //set health to max
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(50);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Defend(50,1);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Heal(50);
        }*/
        healthBar.value = currentHealth;
    }

    public void TakeDamage (int damage){
        //subtract damage from current health
        currentHealth -= damage;
        //play hit animation
        animator.SetTrigger("hit");
        //check if dead
        if (currentHealth <= 0){
            Dies();
        }
    }

    public void Heal (int regen){
        //play heal animation
        animator.SetTrigger("heal");
        //add hp to current health
        currentHealth += regen;
        //check if over max health
        if (currentHealth > maxHealth){
            //set to max instead
            currentHealth = maxHealth;
        }
    }

    public void Defend (int block, int shieldIndex){
        //play defend animation
        animator.SetTrigger("defend");
        //instantitate new shield
        GameObject shieldClone = Instantiate(shields[shieldIndex], shields[shieldIndex].transform.position, shields[shieldIndex].transform.rotation);
        shieldScript shieldScript = shieldClone.GetComponent<shieldScript>();
        shieldScript.setHealth(block);
        shieldClone.SetActive(true);
    }

    private void Dies(){
        //delete slider fill
        fill.SetActive(false);
        //play death animation
        animator.SetTrigger("dies");
        SceneManager.GetComponent<PlayGameManager>().DeathScreen();
    }

    /*
    //called with keyframe event in dies animation
    private void afterDeath(){
        //delete game object
        Destroy(gameObject);
        //load Game Over scene
        SceneManager.LoadScene(2);
    }
    */
    private void fadeToBlack(){
        //fade to black
        resetScreenAnimator.SetTrigger("fade");
    }
}
