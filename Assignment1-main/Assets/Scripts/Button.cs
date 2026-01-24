using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Button : MonoBehaviour
{

    public GameObject button;
    public GameObject bread;
    public GameObject player;
    public GameObject objects;
    public GameObject money;
    public Transform moneySpawnPoint;

    public ParticleSystem fire;
    public float cookTime = 5f;

    public UnityEvent onPress;
    public UnityEvent onRelease;

    Vector3 startPos;


    bool isPressed;
    private bool moneySpawned = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPressed = false;

        startPos = button.transform.localPosition; //start position of the red button
    }

    private void OnTriggerEnter(Collider other)
    {
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

    // Cooking bread when button is pressed
    public void Cook()
    {
        StartCoroutine(CookRoutine());

        //spawn the money
        if (moneySpawned)

        {
            objects.SetActive(true);
        }
    }

    IEnumerator CookRoutine()
    {
        if (fire != null)
        {
            fire.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            fire.Play();
            Debug.Log("Cooking started");
            MusicManager.instance.PlaySound("Cooking");
        }    


        // Wait for cooking time
        yield return new WaitForSeconds(cookTime);

        // Stop particles
        if (fire != null)
        {
            fire.Stop();
        }

        // Show bread
        bread.SetActive(true);

        if (!moneySpawned)
        {
            Instantiate(money, moneySpawnPoint.position, moneySpawnPoint.rotation);
            moneySpawned = true;
        }
    }
}
