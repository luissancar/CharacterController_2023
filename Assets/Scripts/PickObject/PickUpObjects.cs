using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ///////
/// </summary>
public class PickUpObjects : MonoBehaviour
{
    public GameObject objectToPickup;
    public GameObject picketObject;
    public Transform mochila;


    // Update is called once per frame
    void Update()
    {
        if (objectToPickup != null &&
            objectToPickup.GetComponent<PickableObject>().isPickable
            && picketObject == null)
        { 
            if (Input.GetKeyDown(KeyCode.C))
            {
                picketObject = objectToPickup;
                picketObject.GetComponent<PickableObject>().isPickable
                    = false;
                picketObject.transform.SetParent(mochila);
                picketObject.transform.position = mochila.position;
                picketObject.GetComponent<Rigidbody>().useGravity = false;
                picketObject.GetComponent<Rigidbody>().isKinematic = true;
            }
                

        }
        else if (picketObject != null)
        {

            if (Input.GetKeyDown(KeyCode.C))
            {
                picketObject.GetComponent<PickableObject>().isPickable
                    = true;
                picketObject.transform.SetParent(null);
                picketObject.GetComponent<Rigidbody>().useGravity = true;
                picketObject.GetComponent<Rigidbody>().isKinematic = false;
                picketObject = null;

            }


        }
                
        
    }
}