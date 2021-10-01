using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
       [SerializeField] float hitPoints = 100f;

    public AudioSource audioSource;
    public AudioClip alarm;

    bool alreadyPlayed = false;
    public bool isDead = false;
    public bool IsDead() { return isDead; }

    public void TakeDamage(float damage)
    {
        if(gameObject.tag == "Nonhostile")
        {
            PlayAlarm();
        }

        // BroadcastMessage can call a method that is on the game object or any of the game objects children
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        

        if (hitPoints <= 0)
        {
            Die();
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
        // will only allow die animation to play once
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die"); 
    }
}
