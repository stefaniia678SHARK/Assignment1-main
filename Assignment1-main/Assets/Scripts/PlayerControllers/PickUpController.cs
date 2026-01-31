using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Security.Cryptography;
using System.Collections.Specialized;
using UnityEngine.InputSystem;

public class PickUpController : MonoBehaviour
{
    [SerializeField] Transform holdArea;

    public GameObject heldObject;
    private Rigidbody heldObjectRb;

    [SerializeField] public float pickUpRange = 5.0f;
    [SerializeField] private float pickUpforce = 150.0f;

    public void Update()
    {
        if (heldObject != null)
        {
            MoveObject();
        }
    }

   public void PickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            heldObjectRb = pickObj.GetComponent<Rigidbody>();
            heldObjectRb.useGravity = false;
            heldObjectRb.linearDamping = 10;
            heldObjectRb.constraints = RigidbodyConstraints.FreezeRotation; //not goiong to rotate when we pick it up
            
            heldObjectRb.transform.parent = holdArea;
            heldObject = pickObj;
        }
    }
    public void DropObject()
    {
            heldObjectRb.useGravity = true;
            heldObjectRb.linearDamping = 1;
            heldObjectRb.constraints = RigidbodyConstraints.None;

            heldObjectRb.transform.parent = null ;
            heldObject = null;
    }

    public void MoveObject()
    {
        if (Vector3.Distance(heldObject.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObject.transform.position);
            heldObjectRb.AddForce(moveDirection * pickUpforce);
        }
    }
}
