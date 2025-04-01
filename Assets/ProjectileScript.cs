using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ProjectileScript : MonoBehaviour
{
    public Animator animator;
    public GameObject audioPrefab;
    public AudioClip deathSound;
    public bool projectileCollision;
    public float speed;
    public int health;
    public int damage;
    public bool isMonsoon=false;

    private bool sound_played = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (health <= 0)
        {
            death();
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("On trigger enter");
        if(other.CompareTag("Enemy Projectile")) { Debug.Log("intersecting projectiles"); }
        if (other.CompareTag("Border"))
        {
            Destroy(this.gameObject, .01f);
        }
        else if (other.CompareTag("Enemy") && isMonsoon == false) {
            EnemyBehaviour enemyScript = other.GetComponent<EnemyBehaviour>();
            enemyScript.TakeDamage(damage);

            PlayExplodeAnimation();
            death();
        }
        else if (other.CompareTag("Enemy Projectile"))
            Debug.Log("Colliding with projectiles");
        {
            if(projectileCollision == true)
            {
                int enemyProjDmg = other.gameObject.GetComponent<EnemyProjectileScript>().damage;
                other.gameObject.GetComponent<EnemyProjectileScript>().health -= damage;
                health -= enemyProjDmg;
                Debug.Log("projectile collision: " + health +" enemy health: " + other.gameObject.GetComponent<EnemyProjectileScript>().health);

                PlayExplodeAnimation();
  
            }
        }
    }
    public void death()
    {
        speed = 0;
        PlayExplodeAnimation();
        Destroy(this.gameObject, 0.18f);
    }

    public void PlayCollideAnimation()
    {

    }
    public void PlayExplodeAnimation()
    {

        
        animator.SetTrigger("explode");
        if(!sound_played){
            sound_played = true;
            GameObject audioPlayer = Instantiate(audioPrefab, transform.position, Quaternion.identity);

            // Get the AudioSource component from the prefab
            AudioSource audioSource = audioPlayer.GetComponent<AudioSource>();
            
            // Assign the death sound clip if it's not already assigned in the prefab
            if (deathSound != null)
            {
                audioSource.clip = deathSound;
            }

            // Play the sound
            audioSource.Play();
            Debug.Log("play");

            // Destroy the audio player after the sound finishes
            Destroy(audioPlayer, audioSource.clip.length);
        }
        
    }
}
