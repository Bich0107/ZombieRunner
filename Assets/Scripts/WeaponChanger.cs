using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    int weaponAmount;

    void Start()
    {
        weaponAmount = transform.childCount;
        SetWeaponActive();
    }

    void OnChangeWeapon(InputValue inputValue)
    {
        ProcessKeyInput(inputValue);
    }

    void OnMouseScroll(InputValue inputValue)
    {
        ProcessScrollWheel(inputValue);
    }

    void ProcessKeyInput(InputValue inputValue)
    {
        int previousWeapon = currentWeapon;
        currentWeapon = (int)inputValue.Get<float>();
        if (currentWeapon != previousWeapon) SetWeaponActive();
    }

    void ProcessScrollWheel(InputValue inputValue)
    {
        int previousWeapon = currentWeapon;

        float yValue = inputValue.Get<Vector2>().y;
        if (yValue < 0)
        {
            currentWeapon = currentWeapon - 1 < 0 ? weaponAmount - 1 : currentWeapon - 1;
        }
        else if (yValue > 0)
        {
            currentWeapon = (currentWeapon + 1) % weaponAmount;
        }

        if (currentWeapon != previousWeapon) SetWeaponActive();
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
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
