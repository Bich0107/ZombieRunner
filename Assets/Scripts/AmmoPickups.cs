using UnityEngine;

public class AmmoPickups : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] int ammoAmount = 5;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<Ammo>()?.IncreaseCurrentAmmo(ammoType, ammoAmount);
            Destroy(gameObject);  
        }
    }
}
