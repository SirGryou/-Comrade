using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideUI : MonoBehaviour
{
    public GameObject uiHide;
    public void HideUi()
    {

        uiHide.SetActive(false);
    }
}
