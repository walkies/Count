using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public GameObject ball;
    public GameObject Canvas;
    public GameObject Panel;
    public GameObject ballentry;
    public GameObject table;
    public AudioSource audio1;
    public int currentTime;
    public int currentScore;
    public Text Count;
    public Text Score;
    public Text Scoreboard;

    void Start()
    {
        audio1 = table.GetComponent<AudioSource>();
        StartCoroutine(StartCountdown());
    }
    void Update()
    {
        Count.text = "" + currentTime.ToString();
        Score.text = "" + currentScore.ToString();
        Scoreboard.text = "" + currentScore.ToString();

        if (currentScore == 30)
        {
            spawnball();
        }
        else if (currentScore == 80)
        {
            spawnball();
        }
        else if (currentScore == 120)
        {
            spawnball();
        }
        else if (currentScore == 160)
        {
            spawnball();
        }
        else if (currentScore == 200)
        {
            spawnball();
        }
        else if (currentScore == 240)
        {
            spawnball();
        }
        else if (currentScore == 280)
        {
            spawnball();
        }
    }

    public IEnumerator StartCountdown(int countdownValue = 100)
    {
        currentTime = countdownValue;
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currentTime--;
            audio1.pitch = audio1.pitch + 0.00032f;
        }
        if (currentTime <= 0)
        {
            Time.timeScale = 0;
            Panel = Canvas.transform.Find("EndPanel").gameObject;
            Panel.SetActive(true);
        }
    }
    void spawnball()
    {
        ballentry.GetComponent<AudioSource>().Play();
        Instantiate(ball, new Vector3(0, 3f, 2), Quaternion.Euler(0, 180, 0));
        currentScore++;
    }
}


