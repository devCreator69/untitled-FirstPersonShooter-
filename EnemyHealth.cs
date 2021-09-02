using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public AudioSource audioSource;
    public AudioClip alarm;

   
    bool alreadyPlayed = false;

    bool isDead = false;
    public bool IsDead() { return isDead; }

    public void TakeDamage(float damage)
    {
        // BroadcastMessage can call a method that is on the game object or any of the game objects children
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
            //Destroy(gameObject); 
        }
        
    }

    private void PlayAlarm () 
    {
        if (!alreadyPlayed)
        {
            audioSource.PlayOneShot(alarm);
            alreadyPlayed = true;
        }
    }
 
    private void Die()
    {
        if(gameObject.tag == "Nonhostile")
        {
            Debug.Log("I was Nonhostile");
            PlayAlarm();

            if (isDead) return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
        else
        {
            // will only allow die animation to play once
            if (isDead) return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("die"); 
        }
    }
}
