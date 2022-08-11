using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradePointUI : MonoBehaviour
{
    private int upgradePoint;
    public TextMeshProUGUI textUpgradePoint;
    void Start()
    {
        if (!PlayerPrefs.HasKey("Upgrade Point"))
        {
            upgradePoint = 1;
        }
        else
        {
            upgradePoint = PlayerPrefs.GetInt("Upgrade Point");
        }

    }

    void Update()
    {
        upgradePoint = PlayerPrefs.GetInt("Upgrade Point");
        textUpgradePoint.text = "Upgrade Pts: " + upgradePoint.ToString();
    }
}
