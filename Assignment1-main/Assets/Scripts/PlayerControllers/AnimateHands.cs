using UnityEngine; 
using UnityEngine.InputSystem;

public class AnimateHands : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public InputActionProperty triggerValue;
    public InputActionProperty gripValue;

    public Animator handAnimator;


    // Update is called once per frame
    void Update()
    {

        float trigger = triggerValue.action.ReadValue<float>();
        float grip = gripValue.action.ReadValue<float>();

        handAnimator.SetFloat("Trigger", trigger);
        handAnimator.SetFloat("Grip", grip);
    }
}
