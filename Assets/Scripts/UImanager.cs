using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{

    Canvas MainMenuCanvas, ControlsMenuCanvas, OptionsMenuCanvas;

    public enum GameState
    {
        MainMenu,
        OptionsMenu,
        ControlsMenu,
    }

    public GameState currentState;

    void Start()
    {
        MainMenuCanvas = GameObject.Find("MainMenu").gameObject.GetComponent<Canvas>();
        OptionsMenuCanvas = GameObject.Find("OptionsMenu").gameObject.GetComponent<Canvas>();
        ControlsMenuCanvas = GameObject.Find("ControlsMenu").gameObject.GetComponent<Canvas>();
        ChangeState(GameState.MainMenu);
    }

    void Update()
    {

    }

    //gamestates
    IEnumerator MainMenuState()
    {
        ControlsMenuCanvas.enabled = false;
        OptionsMenuCanvas.enabled = false;
        MainMenuCanvas.enabled = true;

        while (currentState == GameState.MainMenu)
        {
            yield return null;
        }

        MainMenuCanvas.enabled = false;

    }

    IEnumerator OptionsMenuState()
    {
        OptionsMenuCanvas.enabled = true;
        ControlsMenuCanvas.enabled = false;

        while (currentState == GameState.OptionsMenu)
        {
            yield return null;
        }

        OptionsMenuCanvas.enabled = false;
    }
    IEnumerator ControlsMenuState()
    {
        ControlsMenuCanvas.enabled = true;
        OptionsMenuCanvas.enabled = false;

        while (currentState == GameState.ControlsMenu)
        {
            yield return null;
        }

        ControlsMenuCanvas.enabled = false;
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        StartCoroutine(newState.ToString() + "State");
    }

    public void readyState(GameState newState)
    {
        SceneManager.LoadScene("Game");
    }


}
