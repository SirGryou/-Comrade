using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    Text text;
    public static int cashAmount;

    void Start()
    {
        text = GetComponent<Text>();   
    }

    void Update()
    {
        text.text = cashAmount.ToString();
    }
}
