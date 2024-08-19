using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 60f;
    [SerializeField] float addIntensity = 1f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided");

            FlashLightSystem flashLight = other.GetComponentInChildren<FlashLightSystem>();
            if (flashLight != null)
            {
                flashLight.RestoreLightAngle(restoreAngle);
                flashLight.RestoreLightIntensity(addIntensity);
                Destroy(gameObject);
            }
        }
    }
}
