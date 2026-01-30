/*using UnityEngine;
using TMPro;

public class ChooseControllers : MonoBehaviour
{
    public GameObject planeA;
    public GameObject planeB;

    public TMP_Text textGood;
    public TMP_Text textToShow;
    public TMP_Text textToHide;

    public Camera cam;          // assign your main camera in the Inspector
    public LayerMask clickMask; // set to the layer(s) your planes are on

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f, clickMask))
            {
                // If you only care that you clicked *any* plane, just switch
                SwitchPlanes();
            }
        }
    }

    void SwitchPlanes()
    {
        bool aIsActive = planeA.activeSelf;

        planeA.SetActive(!aIsActive);
        planeB.SetActive(aIsActive);

        textToShow.gameObject.SetActive(true);
        textToHide.gameObject.SetActive(false);
        textGood.gameObject.SetActive(true);
    }
}

*/