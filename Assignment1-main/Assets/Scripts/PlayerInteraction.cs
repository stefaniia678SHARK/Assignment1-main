using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 5f;
    public Camera playerCamera;
    public MouseInterec MouseInterecScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange))
        {    

            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                // Button button = hit.collider.GetComponent<Button>();
                // button.Press();

            }

            return;
            
        }


    }
}
