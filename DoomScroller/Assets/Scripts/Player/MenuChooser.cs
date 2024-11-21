using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuChooser : MonoBehaviour
{

    public GameObject keyboard;
    public GameObject playstation;
    public GameObject xbox;

    public PlayerInput playerInput;

    void Awake(){
        playerInput = GameObject.Find("InputManager").GetComponent<PlayerInput>();
    }

    void Start()
    {
        CorrectMenu();
    }

    public void CorrectMenu(){
        CheckCurrentInputMethod();
    }

    public void CheckCurrentInputMethod()
    {
        // List all devices currently used
        foreach (InputDevice device in playerInput.devices)
        {
            Debug.Log("Device: " + device.displayName);
        }

        // Optionally, apply changes based on the device type
        UpdateUIBasedOnDevice(playerInput.devices[0]);
    }

    public void UpdateUIBasedOnDevice(InputDevice device)
    {
        if (device is Keyboard)
        {
            ChangeMenuTo("Keyboard");
        }
        else if (device is Gamepad gamepad)
        {
            if (gamepad.description.manufacturer.Contains("Sony"))
                ChangeMenuTo("PlayStation");
            else if (gamepad.description.manufacturer.Contains("Microsoft"))
                ChangeMenuTo("Xbox");
            // Add other conditions as necessary
        }
    }

    public void ChangeMenuTo(string deviceType)
    {
        //Debug.Log("Changing menu to: " + deviceType);
        // Implement your menu changing logic here.
        if(deviceType == "Keyboard")
        {
            keyboard.SetActive(true);
            playstation.SetActive(false);
            xbox.SetActive(false);
        }

        if(deviceType == "PlayStation") 
        {
            keyboard.SetActive(false);
            playstation.SetActive(true);
            xbox.SetActive(false);
        }

        if(deviceType == "Xbox")
        {
            keyboard.SetActive(false);
            playstation.SetActive(false);
            xbox.SetActive(true);
        }
    }
}