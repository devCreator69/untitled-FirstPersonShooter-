using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20;
    [SerializeField] float timeBetweenShots = 0.5f;

    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;

    [SerializeField] AudioSource fireSound;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;

    [SerializeField] float firingRate = 0.2f;
    [SerializeField] float nextFire = 0.0f;
    [SerializeField] TextMeshProUGUI ammoText;

    void Update()
    {
        DisplayAmmo();
        // left mouse click = GetMouseButtonDown(0)
        // Time.time us the time in seconds since the start of the application
        if(Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
           nextFire = Time.time + firingRate;
           Shoot();
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    private void Shoot()
    { 
        if(ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            fireSound.Play();
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();  
    }

     private void ProcessRaycast()
    {
        RaycastHit hit;
        // Physics.Raycast casts a ray from an origin point, in a direction and of a certain length
       
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {

            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            // if no enemy was hit, EnemyHealth script wont be called
            if(target == null) return;
            target.TakeDamage(damage);
        }
            // To gaurd against errors when we shoot and hit nothing 
        else
        {
            return;
        }

        void CreateHitImpact(RaycastHit hit)
        {
            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 1);
        }
    }
}
