using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{ 
    public float hitPoints, maxHealth = 100f; 
    public GameObject hitCanvas; 
    public float maxColorStrength;
    public float minColorStrength;
    public AudioSource playerHitSound;

    // Player health bar
    public Image healthBar;
    float lerpSpeed;
    float fillTime = 3f;


    void Start() 
    {
        hitPoints = maxHealth;
    }
    void Update()
    {
        ScreenFlashFade();
        HealthBarFiller();
        ColorChanger();
        
        if(hitPoints > maxHealth) hitPoints = maxHealth;
        lerpSpeed = fillTime * Time.deltaTime;
    }
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        ScreenFlash();
        playerHitSound.Play();

        if (hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
            healthBar.fillAmount = 0;
        }
    }

    void HealthBarFiller() 
    {
        // Lerp takes initial value, final value and a speed
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, hitPoints / maxHealth, lerpSpeed);
    }

    void ColorChanger() 
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (hitPoints / maxHealth));

        healthBar.color = healthColor;  
    }

    void ScreenFlash()
    {
        var color = hitCanvas.GetComponent<Image>().color;
        // color.a refrences the alpha of the image
        color.a = maxColorStrength;
        // assigns the color back to the image
        hitCanvas.GetComponent<Image>().color = color;
    }
    void ScreenFlashFade()
    {
        // if hitCanvas is assigned
        if(hitCanvas != null)
        {
            if(hitCanvas.GetComponent<Image>().color.a > 0)
            {
                var color = hitCanvas.GetComponent<Image>().color;
                color.a -= minColorStrength;
                hitCanvas.GetComponent<Image>().color = color;
            }
        }
    }
}
