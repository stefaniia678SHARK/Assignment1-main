using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 5f;
    public Camera playerCamera;
    public MouseInterec MouseInterecScript;

    public PickUpController pickupScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        bool hitSomething = Physics.Raycast(ray, out hit, interactRange);

        CookButton cookButton = null;
        
        if (hitSomething)
        {
            cookButton = hit.collider.GetComponent<CookButton>();
        }

        MouseInterecScript.SetInteract(cookButton != null);
   
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (cookButton != null)
            {
                cookButton.Press();
                return;
            }

            if (pickupScript.heldObject != null)
            {
                pickupScript.DropObject();
                return;
            }

            if (hitSomething && hit.collider.GetComponent<Rigidbody>() != null)
            {
                pickupScript.PickUpObject(hit.collider.gameObject);
                return;
            }


        }

        if (pickupScript.heldObject != null)
        {
            pickupScript.MoveObject();
        }

        return;
    }
}
