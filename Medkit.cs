using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
// in order to access the variable hitPoints from PlayerHealth I made this script inherit from it instead of MonoBehaviour
{
    [SerializeField] float medkitLifeIncrease;
    [SerializeField] AudioSource medkitSound;
    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerHealth.hitPoints += medkitLifeIncrease;
          //  medkitSound.Play();
            Destroy(gameObject);
        }
    }
}
