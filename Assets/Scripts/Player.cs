using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    void Start()
    {
        Time.timeScale = 1;
    }


    void Update()
    {
        if (Superscript.whatState == 1)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector2.up * Time.deltaTime * 85);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector2.down * Time.deltaTime * 85);
            }
        }
        else if (Superscript.whatState == 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector2.up * Time.deltaTime * 85);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector2.down * Time.deltaTime * 85);
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }
   }
}
