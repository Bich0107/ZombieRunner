using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] DeathHandler deathHandler;
    [SerializeField] float hitPoints = 100f;
    [SerializeField] float currentHitpoints;

    void Start() {
        deathHandler = GetComponent<DeathHandler>();
        currentHitpoints = hitPoints;
    }

    public void TakeDamage(float _damage) {
        currentHitpoints -= _damage;

        if (currentHitpoints <= 0f) {
            Die();
        }
    }

    void Die() {
        deathHandler.HandleDeath();
    }
}
