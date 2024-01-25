using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootraycastExercise : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private LayerMask _layerMask; 
    private Renderer renDerer;
    private Rigidbody rigidB;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(shootPoint.transform.position, transform.TransformDirection(Vector3.forward * 20f), Color.black);

        if (Physics.Raycast(shootPoint.transform.position,
                transform.TransformDirection(Vector3.forward),
                out RaycastHit raycastHit, 20f , _layerMask))
        {
            Debug.Log($"Hit {raycastHit.collider.gameObject.tag}");
            Debug.DrawRay(shootPoint.transform.position, transform.TransformDirection(Vector3.forward * 20f) ,new Color32(255,128,0,255));

            renDerer = raycastHit.collider.gameObject.GetComponent<Renderer>();
            if (renDerer != null)
            {
                renDerer.material.color = new Color32(216, 48, 105, 255);
            }

            rigidB = raycastHit.collider.gameObject.GetComponent<Rigidbody>();
            if (rigidB != null)
            {
                rigidB.isKinematic = false;
                rigidB.velocity = Vector3.down *20f;
            }
        }
        else
        {
            Debug.Log("Hit Nothing LOL");
        }
    }
}
