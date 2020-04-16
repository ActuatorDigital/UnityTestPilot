// Copyright (c) AIR Pty Ltd. All rights reserved.

using UnityEngine;
using UnityEngine.UI;

public class ConnectionStatusIndicator : MonoBehaviour
{
    [SerializeField] private Image _connectionIcon = null;
    [SerializeField] private Text _connectionText = null;

    public void DisplayStatus(bool connected)
    {
        _connectionIcon.color = connected ? Color.green : Color.red;
        _connectionText.text = connected ? "Connected" : "Disconnected";
    }
}