using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// se asigna a player
public class pushRigidBody : MonoBehaviour
{
    public float pushPower = 2.0f;
    private float targetMass;


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic) // no tiene rigidbody
        {
            return;
        }

        if (hit.moveDirection.y < -0.3) // empujamos abajo
        {
            return;
        }

        targetMass = body.mass;
        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 
            0, hit.moveDirection.z);
        body.velocity = pushDirection * pushPower / targetMass;
    }
}