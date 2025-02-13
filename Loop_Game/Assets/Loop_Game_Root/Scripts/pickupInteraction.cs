using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInteraction : MonoBehaviour
{
    public GameObject activatePickup;
    public GameObject disablePickup;
    public float deactivateDelay = 3f; // Tiempo en segundos antes de desactivar activateObject

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (activatePickup != null)
            {
                activatePickup.SetActive(true);
                Invoke(nameof(DeactivateActivateObject), deactivateDelay); // Desactiva después de 3 segundos
            }

            if (disablePickup != null)
            {
                disablePickup.SetActive(false);
            }
        }
    }

    private void DeactivateActivateObject()
    {
        if (activatePickup != null)
        {
            activatePickup.SetActive(false);
        }
    }
}