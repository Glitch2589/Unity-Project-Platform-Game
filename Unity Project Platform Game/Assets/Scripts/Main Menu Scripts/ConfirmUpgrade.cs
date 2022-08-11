using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmUpgrade : MonoBehaviour
{
    public GameObject uiObject;

    public void TurnOffUI()
    {
        uiObject.SetActive(false);
    }
    public void TurnOnUI()
    {
        uiObject.SetActive(true);
    }
}
