using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour {

    //references
    [Header("Game Objects")]
    public GameObject gameManager;
    public GameObject pekoraDed;
    public Slider healthBar;
    public GameObject fill;

    [Header("Animation")]
    public Animator animator;
    public float normalAttackWait;
    public float chargedAttackWait;
    
    //current variables
    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;
    private bool isDead = false;

    [Header("AI Settings")]
    public float attackIntervalMin = 1f;
    public float attackIntervalMax = 3f;

    [Header("Attacks")]
    public GameObject normalAttack;
    public GameObject chargedAttack;
    public int normalAttackDmg = 10;
    public int chargeAttackDmg = 50;
    private GameObject projectile;


    void Start() {
        //set health to max
        currentHealth = maxHealth;

        //debug
        if (gameManager == null)
        {
            Debug.Log("GameManager not found.");
        }

        if (animator == null)
        {
            Debug.Log("Animator component not found.");
        }

        StartCoroutine(AttackRoutine());
    }

    void Update() {
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(50);
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

    private void Dies(){
        //set death boolean to true
        isDead = true;
        //play death animation
        animator.SetTrigger("dies");
        //delete slider fill
        fill.SetActive(false);
        //delete game object
        pekoraDed.SetActive(true);
        Destroy(gameObject);
    }

    private IEnumerator AttackRoutine(){
        while (!isDead)
        {
            //wait random time between min and max attack intervals
            float waitTime = Random.Range(attackIntervalMin, attackIntervalMax);
            yield return new WaitForSeconds(waitTime);

            //then attack
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack(){
        //random attack type between 0 and 5
        int attackType = Random.Range(0, 6);
        //(80% chance of normal attack)
        if (attackType < 5){
            //play normal animation and wait
            animator.SetTrigger("normalAttack");
            yield return new WaitForSeconds(normalAttackWait);

            shootProjectile(0);
        }
        //(20% chance of charged attack)
        else {
            //play charge animation and wait
            animator.SetTrigger("chargeAttack");
            yield return new WaitForSeconds(chargedAttackWait);

            shootProjectile(1);
        }
    }

    private void shootProjectile(int attackType){
        //attackType = 0 = normal attack
        if (attackType == 0){
            projectile = Instantiate(normalAttack, normalAttack.transform.position, normalAttack.transform.rotation);
            //ProjectileMove projectileScript = projectile.GetComponent<ProjectileMove>();
            //projectileScript.setDamage(normalAttackDmg);
        }
        //else charged attack spawn
        else {
            projectile = Instantiate(chargedAttack, chargedAttack.transform.position, chargedAttack.transform.rotation);
            //ProjectileMove projectileScript = projectile.GetComponent<ProjectileMove>();
            //projectileScript.setDamage(chargeAttackDmg);
        }
        projectile.SetActive(true);
    }
}
