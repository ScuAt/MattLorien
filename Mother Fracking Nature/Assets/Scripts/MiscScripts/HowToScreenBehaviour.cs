using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HowToScreenBehaviour : MonoBehaviour
{
    InputActionAsset inputAsset4;
    InputActionMap playerActions;
    InputAction openHowTo;
    InputAction closeHowTo;

    public GameObject playerPrefab;

    public GameObject howToScreen;
    public GameObject closeScreen;
    public GameObject openScreen;

    private void Awake()
    {
        inputAsset4 = playerPrefab.GetComponent<PlayerInput>().actions;
        playerActions = inputAsset4.FindActionMap("PlayerActions");

        openHowTo = playerActions.FindAction("OpenHowTo");
        openHowTo.performed += ctx => openHowToScreen();

        closeHowTo = playerActions.FindAction("CloseHowTo");
        closeHowTo.performed += ctx => closeHowToScreen();
    }

    public void Start()
    {
        howToScreen.SetActive(false);
        closeScreen.SetActive(false);
        openScreen.SetActive(true);
    }

    public void openHowToScreen()
    {
        howToScreen.SetActive(true);
        openScreen.SetActive(false);
        closeScreen.SetActive(true);
    }

    public void closeHowToScreen()
    {
        howToScreen.SetActive(false);
        openScreen.SetActive(true);
        closeScreen.SetActive(false);
    }
}
