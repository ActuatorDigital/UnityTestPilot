// Copyright (c) AIR Pty Ltd. All rights reserved.

using UnityEngine;
using UnityEngine.UI;

public class RiderButtonExample : MonoBehaviour
{

    [SerializeField] private GridLayoutGroup _clickPanel = null;
    [SerializeField] private GridLayoutGroup _simulatePanel = null;

    public void Start()
    {
        SetupButtons(_clickPanel, "G", Color.green, true);
        SetupButtons(_simulatePanel, "B", Color.blue, false);
    }

    private void SetupButtons(GridLayoutGroup buttonGroup, string affix, Color color, bool drive)
    {
        var childButtons = buttonGroup.GetComponentsInChildren<Button>();
        foreach (var childButton in childButtons) {
            string buttonName = "Button_" + childButton.transform.GetSiblingIndex() + "_" + affix;
            childButton.name = buttonName;
            childButton.image.color = color;
            childButton.GetComponentInChildren<Text>().text = buttonName;
            if (drive)
                childButton.onClick.AddListener(() => { Debug.Log(childButton.name); });
        }
    }
}