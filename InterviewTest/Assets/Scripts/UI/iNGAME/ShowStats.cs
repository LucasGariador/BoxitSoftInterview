using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowStats : MonoBehaviour
{
    public static float speed = 0;
    TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        text.text = speed.ToString();
    }
}
