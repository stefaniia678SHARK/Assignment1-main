using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Button : MonoBehaviour
{

    public GameObject button;
    public GameObject bread;
    public GameObject player;

    public UnityEvent onPress;
    public UnityEvent onRelease;

    Vector3 startPos;

    AudioSource sound;
    bool isPressed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sound = GetComponent<AudioSource>();
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
            sound.Play();
            isPressed = true;
            Debug.Log("Button Pressed");
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
        bread.SetActive(true);
    }
}
