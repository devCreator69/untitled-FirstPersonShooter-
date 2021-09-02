using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    [SerializeField] int currentWeapon;


    void Start()
    {
        SetWeaponActive();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if(previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }  
    }
    private void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    private void ProcessScrollWheel()
    {
        // scroll wheel is going in a positive direction (up) 
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            // if scrollwheel has reached last weapon there is no weapon left so it needs to loop back to place 0
            // -1 is added to account for weapon 1 being at place 0
            if (currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
        // mouse scroll down to switch back through weapons
        else if(Input.GetAxis("Mouse ScrollWheel") > 0 )
        {
            // once the weapon count reaches the weapon at place 0 it needs to loop back to the weapon in the last place
            if(currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1; 
            }
            else
            {
                currentWeapon--;
            }
        }
    }
    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        // Transform refers to the trasform of the Weapons parent, weapon in transform refers to 
        // its childern, which are teh specific types of guns in the hierarchy
        foreach(Transform weapon in transform)
        {
            if(weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true); 
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}