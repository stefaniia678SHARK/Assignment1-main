using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchModes : MonoBehaviour
{
    public static bool SavedDesktopMode = true;

    public GameObject desktopPlayer;
    public GameObject vrPlayer;
    public GameObject desktopUI;

    public bool startInDesktop = true;

    private bool isDesktop;

    public bool waitForChoice = false;

    public MonoBehaviour desktopMovement;

    void Start()
    {
        if (waitForChoice)
        {
            return;
        }

        // If coming from previous scene, use saved value
        isDesktop = SavedDesktopMode;
        SetDesktopMode(isDesktop);
    }

        void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SetDesktopMode(!isDesktop);
        }
    }

    public void SetDesktopMode(bool desktop)
    {
        SavedDesktopMode = desktop;
        isDesktop = desktop;

        if (desktopPlayer != null)
        {
            desktopPlayer.SetActive(desktop);
        }

        if (vrPlayer != null)
        {
            vrPlayer.SetActive(!desktop);
        }

        if (desktopMovement != null)
        {
            desktopMovement.enabled = desktop;
        }

        if (desktopUI != null)
        {
            desktopUI.SetActive(desktop);
        }

        // cursor handling
        Cursor.lockState = desktop ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !desktop;

        Debug.Log(desktop ? "Desktop Mode" : "VR Mode");
    }
}
