using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeUI : MonoBehaviour
{
    Text text;
    public static int grenadeAmount;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = grenadeAmount.ToString();
    }
}
