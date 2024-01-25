using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ShootRaycast : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private LayerMask _layerMask;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(shootPoint.transform.position, Vector3.forward * 20f, new Color32(255,128,0,255));

        if (Physics.Raycast(shootPoint.transform.position,
                            transform.TransformDirection(Vector3.forward),
                            out RaycastHit raycastHit, 20f , _layerMask))
        {
            Debug.Log($"Hit {raycastHit.collider.gameObject.tag}");
            Debug.DrawRay(shootPoint.transform.position, Vector3.forward *20 , Color.green);
        }
        else
        {
            Debug.Log("Hit Nothing LOL");
        }
    }
}
