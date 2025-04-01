using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSpellSpawner : MonoBehaviour
{
    public Animator playerAnimator;

    public GameObject[] Spells;
    public AudioSource songs;

    public GameObject theeePlayer;


   public GameObject magic;
    public void summonSpell(int spellIndex)
    {
        //rock wall
        switch (spellIndex){
            //rock wall
            case 3: 
                Debug.Log("spawning: shield");
                playerAnimator.SetTrigger("defend");
                theeePlayer.GetComponent<PlayerBehaviour>().Defend(20,0);
            break;

            //mudbrick shield
            case 8: 
                playerAnimator.SetTrigger("defend");
                theeePlayer.GetComponent<PlayerBehaviour>().Defend(50,1);
            break;

            //obi wall
            case 11: 
                playerAnimator.SetTrigger("defend");
                theeePlayer.GetComponent<PlayerBehaviour>().Defend(150,2);
            break;

            //wall of fire
            case 12: 
                playerAnimator.SetTrigger("defend");
                theeePlayer.GetComponent<PlayerBehaviour>().Defend(150,2);
            break;

            case 13: 
                magic.GetComponent<SpellManager>().manaGainRate += 2.0f;
            break;

            default:
            playerAnimator.SetTrigger("attack");
            break;
        }
        songs.Play(0);
        GameObject theSpell = Instantiate(Spells[spellIndex], new Vector2(-5, 2), Quaternion.identity);
    }
}
