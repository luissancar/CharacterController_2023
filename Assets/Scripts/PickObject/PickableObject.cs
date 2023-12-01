using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public bool isPickable = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerInteractionZone")
        {
            Debug.Log(("fffff"));
            other.GetComponentInParent<PickUpObjects>().objectToPickup 
                = this.gameObject;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerInteractionZone")
        {
            other.GetComponentInParent<PickUpObjects>().objectToPickup
                = null;
        }

    }
}