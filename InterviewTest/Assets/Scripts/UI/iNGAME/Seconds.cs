using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Seconds : MonoBehaviour
{
    private int seconds;
    TMP_Text text;


    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        seconds = (int)Time.time;
        text.text = ("Seconds: ") + seconds.ToString();
    }

}
