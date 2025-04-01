using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript : MonoBehaviour
{
    public int addHealthAmt;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        PlayerBehaviour playerScript = player.GetComponent<PlayerBehaviour>();
        playerScript.Heal(addHealthAmt);

        Destroy(this.gameObject, 0.01f);
    }
}
