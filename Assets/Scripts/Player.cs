using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Viewchanger view;
    void Start()
    {
        Time.timeScale = 1;
        view = FindObjectOfType<Viewchanger>();
    }


    void Update()
    {
        if (view.inversecontrols == false)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector2.up * Time.deltaTime * 85);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector2.down * Time.deltaTime * 85);
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main Menu");
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector2.up * Time.deltaTime * 85);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector2.down * Time.deltaTime * 85);
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main Menu");
            }
        }
    }
}
