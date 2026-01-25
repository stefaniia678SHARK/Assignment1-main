using UnityEngine;

public class BreadZone : MonoBehaviour
{
    public CookButton cookButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bread"))
        {
            cookButton.SetBreadPresent(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bread"))
        {
            cookButton.SetBreadPresent(false);
        }
    }
}
