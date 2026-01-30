using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchModes : MonoBehaviour
{
    public GameObject desktopPlayer;
    public GameObject vrPlayer;

    public bool startInDesktop = true;

    void Start()
    {
        SetDesktopMode(startInDesktop);
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            bool desktopActive = desktopPlayer.activeSelf;
            SetDesktopMode(!desktopActive);
        }
    }

    void SetDesktopMode(bool desktop)
    {
        desktopPlayer.SetActive(desktop);
        vrPlayer.SetActive(!desktop);

        // Cursor handling
        Cursor.lockState = desktop ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !desktop;

        Debug.Log(desktop ? "Desktop Mode" : "VR Mode");
    }
}
