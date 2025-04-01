using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dedScript : MonoBehaviour
{
    public Animator playerAnimator;
    public GameObject spellScript;

    // Start is called before the first frame update
    void Start()
    {
        //destroy every instance of attacks
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Enemy Projectile");
        foreach (GameObject proj in projectiles)
        {
            Destroy(proj);
        }
        //start duck walkingOut animation
        playerAnimator.SetTrigger("walkOut");

        //stop player from attacking
        SpellManager SpellManager = spellScript.GetComponent<SpellManager>();
        SpellManager.isAbleToAttack = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Delete(){
        Destroy(gameObject);
    }
}
