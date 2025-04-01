using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject ProjectileBasePlayer;


    private int[] playerSpellHp = {1, 2, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65 };//random numbers, should be tuned later
    private int[] playerSpellSpeed = { 10, 20, 50, 100, 150, 200, 250, 300, 350, 400, 450, 500, 550, 600, 650};

    public void spawnPlayerProjectile(int spellIndex)
    {
        GameObject newProjectile = Instantiate(ProjectileBasePlayer, new Vector2(-10, 0), Quaternion.identity);
        newProjectile.GetComponent<ProjectileHandlerPlayer>().hp = playerSpellHp[spellIndex];
        newProjectile.GetComponent<ProjectileHandlerPlayer>().speed = playerSpellSpeed[spellIndex];
    }


}
