using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIP : MonoBehaviour
{
    public GameObject me;

    void Start()
    {
        StartCoroutine(StartCountdown());
    }
    public IEnumerator StartCountdown(int countdownValue = 1)
    {
        while (countdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            Destroy(me);
        }
    }
}
