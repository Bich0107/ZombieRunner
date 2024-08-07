using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 35f;
    [SerializeField] ParticleSystem muzzleFlash;

    void OnFire(InputValue inputValue)
    {
        Shoot();
    }

    void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
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
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
