using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.Events;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

public class ChooseControllers : MonoBehaviour
{
    //script detoicasted to choose controllers at the beginning og the game

    public SwitchModes switchModes;
    public GameObject startMenuUI;

    public TMP_Text instructionText;
    public TMP_Text startText;
    public TMP_Text option1Text;
    public TMP_Text option2Text;
    public TMP_Text lastone;

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

        // choosing by pressing 1 or 2

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

        Plane1.gameObject.SetActive(false);
        Plane2.gameObject.SetActive(false);

        StartCoroutine(BeforeGame());

        Debug.Log("Game Started");
    }

    IEnumerator BeforeGame()
    {
        yield return new WaitForSeconds(5f);

        startText.gameObject.SetActive(false);
        Portal.gameObject.SetActive(true);
        lastone.gameObject.SetActive(true);
    }
}

