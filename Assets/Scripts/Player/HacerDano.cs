using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// asociar al grupo de pinchos
public class HacerDano : MonoBehaviour
{
    public int cantidad = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerVidaDano>().RestarVida(cantidad);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerVidaDano>().RestarVida(cantidad);
        }
    }
}