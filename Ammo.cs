using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // so that all AmmoSlot information can be seen from inspector
    [SerializeField] AmmoSlot[] ammoSlots;
    [System.Serializable]

    // only things residing in the Ammo class can see the AmmoSlot private class
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    // when returning amount of ammo need to know what type of ammo is being used
    // so passing in the argument AmmoType ammoType is necessary 
    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }
    
    // added int ammoAmount argument to incrinment proerly whenever the player runs over an ammo pickup
    // its value is set in AmmoPickups 
    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount += ammoAmount;
    }
    
    // foreach loop through all weapons until it finds and returns a match between the AmmoType that was passed in
    // and the AmmoType on each of the given weapons 
    // if it can't find any matches, it returns null
    // private return AmmoSlot
    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
