using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Añadir a CAmera
public class ThirdPersonCamera : MonoBehaviour
{
    public Vector3 offset; // distancia cámara player
    private Transform target; //player
    [Range(0, 1)] public float lerpValue;
    public float sensibilidad;  // para mover con en ratón


    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void LateUpdate() //último en ejecutar
    {
        // mover objeto desde un vector a otro de forma suave
        // lerpValue = como de rápido hace el movimiento
        transform.position = Vector3.Lerp(transform.position,
            target.position + offset, lerpValue);
        //Girar cámara

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibilidad,
            Vector3.up) * offset;
      //  offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * sensibilidad, Vector3.left) * offset;

        transform.LookAt(target);
    }
}