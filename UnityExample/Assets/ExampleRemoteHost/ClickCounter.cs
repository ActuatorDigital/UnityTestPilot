// Copyright (c) AIR Pty Ltd. All rights reserved.

using UnityEngine;
using UnityEngine.UI;

public class ClickCounter : MonoBehaviour
{
    [SerializeField] private Text _clickLabel = null;
    private int _clickCounter = 0;

    public void HandleCounterButtonClicked()
    {
        _clickCounter++;
        _clickLabel.text = "Times Clicked: " + _clickCounter;
    }
}