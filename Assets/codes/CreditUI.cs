using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreditUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI creditText;

    void Update()
    {
        if (PlayerCredit.instance != null)
        {
            creditText.text = "Kredi: " + PlayerCredit.instance.credits.ToString();
        }
    }
}
