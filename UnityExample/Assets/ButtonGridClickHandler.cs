// Copyright (c) AIR Pty Ltd. All rights reserved.

using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGridClickHandler : MonoBehaviour
{
    public const string ALT_AFFIX = "_ALT";
    public event Action<string> OnButtonClicked;

    [SerializeField] private GridLayoutGroup _clickPanel = null;
    [SerializeField] private GridLayoutGroup _simulatePanel = null;

    public void Start()
    {
        SetupButtons(_clickPanel, Color.green, true);
        SetupButtons(_simulatePanel, Color.blue, false, ALT_AFFIX);
    }

    private void SetupButtons(
        GridLayoutGroup buttonGroup,
        Color color,
        bool drive,
        string affix = ""
    )
    {
        var childButtons = buttonGroup.GetComponentsInChildren<Button>();
        foreach (var childButton in childButtons) {
            string buttonName = "Button_" + childButton.transform.GetSiblingIndex() + affix;
            childButton.name = buttonName;
            childButton.image.color = color;
            childButton.GetComponentInChildren<Text>().text = buttonName;

            childButton.onClick.AddListener(() => {
                if (drive)
                    OnButtonClicked?.Invoke(childButton.name);
                else
                    childButton.image.color = Color.red;
            });
        }
    }
}