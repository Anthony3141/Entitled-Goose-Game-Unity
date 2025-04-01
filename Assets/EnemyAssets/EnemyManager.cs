using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour {
    public GameObject spellScript;
    public Animator playerAnimator;
    public Animator animator;
    public GameObject[] Enemies;
    private int i = 0;
    // Start is called before the first frame update
    public void swapToNextEnemy(){
        //if no more enemies
        if (i >= Enemies.Length - 1){
            //go to win scene
            SceneManager.LoadScene(4);
        }
        else{
            //enemy stuff
            Destroy(Enemies[i]);
            Enemies[i+1].SetActive(true);
            i++;

            //reset player too
            playerAnimator.SetTrigger("walkIn");

            //unfade
            animator.SetTrigger("unfade");

            //enable attacks again
            //stop player from attacking
            SpellManager SpellManager = spellScript.GetComponent<SpellManager>();
            SpellManager.isAbleToAttack = true;
        }
    }
}
