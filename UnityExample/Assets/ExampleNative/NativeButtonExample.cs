// Copyright (c) AIR Pty Ltd. All rights reserved.

using AIR.UnityTestPilot.Drivers;
using AIR.UnityTestPilot.Queries;
using UnityEngine;
using UnityEngine.UI;

public class NativeButtonExample : MonoBehaviour
{
    private UnityDriver _driver;
    [SerializeField] private ButtonGridClickHandler _buttonGridClickHandler = null;

    private void Start()
    {
        _buttonGridClickHandler.OnButtonClicked += ClickCorrespondingButton;
        _driver = new UnityDriverNative();
    }

    private void ClickCorrespondingButton(string buttonName)
    {
        var altButtonName = buttonName + ButtonGridClickHandler.ALT_AFFIX;
        var altButtonElement = _driver.FindElement(By.Type<Button>(altButtonName));
        altButtonElement.LeftClick();
    }
}