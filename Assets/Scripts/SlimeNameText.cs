using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeNameText : MonoBehaviour
{
    private Text nameText;

    private void Awake()
    {
        nameText = GetComponent<Text>();
    }

    public void SetNameText(string newName)
    {
        nameText.text = newName;
    }
}
