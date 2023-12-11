using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlantfom : MonoBehaviour
{
    CharacterController player;

    public Vector3 groundPosition; // posición actual
    Vector3 lastGronudPosition;
    public string groundName;
    public string lastGroundName;


    // rotacion
    Quaternion actualRot;
    Quaternion lastRot;


    //Ellen
    public float factorDivision = 4.2f;
    public Vector3 originOffset;

    void Start()
    {
        player = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGrounded)
        {
            // Línea imaginaría desde un punto a otro
            RaycastHit hit;

            // Sin ellen 
            //   if (Physics.SphereCast(transform.position ,
            //         player.height / factorDivision, -transform.up, out hit)
            //  )
            if (Physics.SphereCast(transform.position + originOffset,
                    player.radius / factorDivision,
                    -transform.up, out hit)
               )
            {
                GameObject groundedIn = hit.collider.gameObject;
                groundName = groundedIn.name;
                groundPosition = groundedIn.transform.position;


                ///Rot
                actualRot = groundedIn.transform.rotation;

                /// 
                // el suelo se mueve y seguimos en la plataforma
                if (groundPosition != lastGronudPosition && 
                    groundName == lastGroundName)
                {
                    this.transform.position 
                        += groundPosition - lastGronudPosition;

                    /////
                    player.enabled = false;
                    player.transform.position = this.transform.position;
                    player.enabled = true;
                }


                ///Rot
                if (actualRot != lastRot && groundName == lastGroundName)
                {
                    var newRot = this.transform.rotation *
                                 (actualRot.eulerAngles - lastRot.eulerAngles);
                    this.transform.RotateAround(groundedIn.transform.position,
                        Vector3.up, newRot.y);
                }

                lastRot = actualRot;

                ///


                lastGroundName = groundName;
                lastGronudPosition = groundPosition;
            }
        }
        else
        {
            lastGroundName = null;
            lastGronudPosition = Vector3.zero;
            lastRot = Quaternion.Euler(0, 0, 0);
        }
    }
/* Sin Ellen
    //Gizmos lineas de los objetos
    // crea un gizmo propio
    private void OnDrawGizmos()
    {
        // raycast más grande
        player = this.GetComponent<CharacterController>();
        Gizmos.DrawWireSphere(transform.position, player.height / 4.2f);
    }*/


// Con Ellen
    private void OnDrawGizmos()
    {
        // raycast más grande
        player = this.GetComponent<CharacterController>();
        Gizmos.DrawWireSphere(transform.position + originOffset, 
            player.radius / factorDivision);
    }
}