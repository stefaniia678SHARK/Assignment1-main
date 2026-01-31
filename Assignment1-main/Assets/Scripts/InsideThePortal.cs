using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Collections;


public class InsideThePortal : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PortalSequence());
        }
    }

    IEnumerator PortalSequence()
    {
        // Animate shader here
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainScene");
    }
}
