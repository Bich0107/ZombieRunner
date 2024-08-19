using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType _ammoType) => ammoSlots[(int) _ammoType].ammoAmount;

    public void ReduceCurrentAmmo(AmmoType _ammoType, int _amount)
    {
        AmmoSlot slot = GetAmmoSlot(_ammoType);
        if (slot == null) return;

        slot.ammoAmount -= _amount;
    }

    public void IncreaseCurrentAmmo(AmmoType _ammoType, int _amount)
    {
        AmmoSlot slot = GetAmmoSlot(_ammoType);
        if (slot == null) return;

        slot.ammoAmount += _amount;
    }

    public bool AmmoCheck(AmmoType _ammoType, int _consumeAmount)
    {
        AmmoSlot slot = GetAmmoSlot(_ammoType);
        if (slot == null) return false;

        return _consumeAmount <= slot.ammoAmount;
    }

    AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (var slot in ammoSlots)
        {
            if (ammoType == slot.ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
