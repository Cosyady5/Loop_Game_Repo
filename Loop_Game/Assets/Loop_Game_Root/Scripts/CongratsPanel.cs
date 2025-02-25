using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratsPanel : MonoBehaviour
{

    public GameObject activateObject;

    void Start()
    {
        if (Input.GetKeyDown(KeyCode.E))

            if (activateObject != null)
            {
                activateObject.SetActive(true);
            }
                
        
    }

}
