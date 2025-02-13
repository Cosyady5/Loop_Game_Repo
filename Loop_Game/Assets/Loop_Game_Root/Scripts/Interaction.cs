using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject activateObject;
    public GameObject disableObject;
    public float deactivateDelay = 3f; // Tiempo en segundos antes de desactivar activateObject

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (activateObject != null)
            {
                activateObject.SetActive(true);
                Invoke(nameof(DeactivateActivateObject), deactivateDelay); // Desactiva después de 3 segundos
            }

            if (disableObject != null)
            {
                disableObject.SetActive(false);
            }
        }
    }

    private void DeactivateActivateObject()
    {
        if (activateObject != null)
        {
            activateObject.SetActive(false);
        }
    }
}
