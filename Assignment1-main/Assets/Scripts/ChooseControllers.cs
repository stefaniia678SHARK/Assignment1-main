using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

public class ChooseControllers : MonoBehaviour
{
    public SwitchModes switchModes;
    public GameObject startMenuUI;

    public TMP_Text instructionText;
    public TMP_Text startText;
    public TMP_Text option1Text;
    public TMP_Text option2Text;

    public GameObject Plane1;
    public GameObject Plane2;
    public GameObject Portal;

    public MonoBehaviour desktopMovement;

    private bool hasChosen = false;

    void Start()
    {
        desktopMovement.enabled = false; // lock movement
        Portal.SetActive(false);
    }

    void Update()
    {
        if (hasChosen) return;

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            ChooseDesktop();
        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            ChooseVR();
        }
    }

    void ChooseDesktop()
    {
        hasChosen = true;
        switchModes.waitForChoice = false;
        switchModes.SetDesktopMode(true);
        option1Text.gameObject.SetActive(true);
        StartGame();
    }

    void ChooseVR()
    {
        hasChosen = true;
        switchModes.waitForChoice = false;
        switchModes.SetDesktopMode(false);
        option2Text.gameObject.SetActive(true);
        StartGame();
    }

    void StartGame()
    {
        instructionText.gameObject.SetActive(false);
        startText.gameObject.SetActive(true);

        Portal.gameObject.SetActive(true);

        Plane1.gameObject.SetActive(false);
        Plane2.gameObject.SetActive(false);

        Debug.Log("Game Started");
    }
}

