using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    public void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        // stops game time from moving once dead
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        // gives player ability to use cursor to restart or quit
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        
        
    }

}
