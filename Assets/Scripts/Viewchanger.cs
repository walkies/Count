using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Viewchanger : MonoBehaviour
{
    private static bool created = false;
    public bool inversecontrols;
    UImanager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<UImanager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }
    public void Inversecontrols()
    {
        inversecontrols = true;
        if (inversecontrols == true)
        {
            inversecontrols = false;
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void MainMenu()
    {
        gameManager.ChangeState(UImanager.GameState.MainMenu);
    }

    public void Options()
    {
        gameManager.ChangeState(UImanager.GameState.OptionsMenu);
    }
    public void Controls()
    {
        gameManager.ChangeState(UImanager.GameState.ControlsMenu);
    }

    public void Quit()
    {
        Debug.Log("working");
        Application.Quit();
    }
}