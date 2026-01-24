using UnityEngine;

public class Bread : MonoBehaviour
{
    public CookButton buttonScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (buttonScript != null)
            {
                buttonScript.BreadCollected();
            }

            Destroy(gameObject);
        }
    }
}
