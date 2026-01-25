using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CookButton : MonoBehaviour
{

    public GameObject button;
    public GameObject player;
    public GameObject objects;

    public GameObject bread;
    public GameObject money;
    public Transform moneySpawnPoint;
    public Transform breadSpawnPoint;

    public TMP_Text TextWarning;

    public ParticleSystem fire;
    public float cookTime = 5f;

    //for button events
    public UnityEvent onPress;
    public UnityEvent onRelease;

    Vector3 startPos;

    private bool breadinZone = false;

    bool isPressed;
    private bool moneySpawned = false;
    private bool isCooking = false;

    void Start()
    {
        isPressed = false;
        startPos = button.transform.localPosition; //start position of the red button
    }

    private void OnTriggerEnter(Collider other)
    {
        if (breadinZone)
        {
            StartCoroutine(ShowWarning("You still have bread! Collect it first and put on the table.")); // change here the warning message
            return;
        }

        if (!isPressed)
        {
            button.transform.localPosition = startPos + Vector3.down * 0.02f;
            player = other.gameObject;
            onPress.Invoke();
            isPressed = true;
            Debug.Log("Button Pressed");
            MusicManager.instance.PlaySound("ButtonClick");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            button.transform.localPosition = startPos;
            onRelease.Invoke();
            isPressed = false;
        }
    }

    // Resetting bread spawn status when collected, referenced in BreadZone.cs
    // so it gets the value from another script to assign if the breadi n zone or no
    // basically controlling entry point

    public void SetBreadPresent(bool present)
    {
        breadinZone = present;
    }

    // Cooking bread when button is pressed
    public void Cook()
    {

        if (isCooking || breadinZone)
        {
            return;
        }

        isCooking = true;
        StartCoroutine(CookRoutine());

    }

    //using IEnumerator to handle the cooking time

    IEnumerator CookRoutine()
    {
        if (fire != null)
        {
            fire.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            fire.Play();
            Debug.Log("Cooking started");
            MusicManager.instance.PlaySound("Cooking");
        }

        yield return new WaitForSeconds(cookTime);

        // Stop particles
        if (fire != null)
        {
            fire.Stop();
        }


        // Spawn the bread
        GameObject spawnedBread = Instantiate(bread, breadSpawnPoint.position, breadSpawnPoint.rotation);
        Debug.Log("Spawning bread at: " + breadSpawnPoint.position + ", rotation: " + breadSpawnPoint.rotation);

        if (!moneySpawned)
        {
            Instantiate(money, moneySpawnPoint.position, moneySpawnPoint.rotation);
            moneySpawned = true;

            //spawn the money
            if (objects != null)

            {
                objects.SetActive(true);
            }
        }

        isCooking = false;

    }

    // Show warning message for a limited time

    IEnumerator ShowWarning(string message)
    {
        TextWarning.text = message;
        TextWarning.gameObject.SetActive(true);

        yield return new WaitForSeconds(10f);  

        TextWarning.gameObject.SetActive(false);
    }
}
