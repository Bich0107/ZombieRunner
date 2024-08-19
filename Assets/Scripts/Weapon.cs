using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 35f;
    [SerializeField] int ammoConsumePerShot = 1;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float reloadTime = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;
    bool reloading = false;

    void OnEnable()
    {
        reloading = false;
    }

    void Update()
    {
        DisplayAmmo();
    }

    void OnFire(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            Shoot();
        }
    }

    void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    void Shoot()
    {
        if (!ammoSlot.AmmoCheck(ammoType, ammoConsumePerShot) || reloading)
        {
            return;
        }

        PlayMuzzleFlash();
        ProcessRaycast();
        ConsumeAmmo();
        StartCoroutine(CR_Reloading());
    }

    IEnumerator CR_Reloading()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
    }

    void ConsumeAmmo()
    {
        ammoSlot.ReduceCurrentAmmo(ammoType, ammoConsumePerShot);
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, range);

        if (hit.collider != null)
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    void CreateHitImpact(RaycastHit _hit)
    {
        GameObject impact = Instantiate(hitEffect, _hit.point, Quaternion.LookRotation(_hit.normal));
        Destroy(impact, 1f);
    }
}
