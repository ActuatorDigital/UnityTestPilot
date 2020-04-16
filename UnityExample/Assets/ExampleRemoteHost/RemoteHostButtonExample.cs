// Copyright (c) AIR Pty Ltd. All rights reserved.

using AIR.UnityTestPilot.Remote;
using UnityEngine;

public class RemoteHostButtonExample : MonoBehaviour
{
    private RemoteUnityAgentHost _host;
    [SerializeField] private ConnectionStatusIndicator _connectionIndicator;

    private void Start()
    {
        const bool NOT_CONNECTED = false;
        _connectionIndicator.DisplayStatus(NOT_CONNECTED);
        var args = new[] { RemoteAgentActivator.VERBOSE_ACTIVATION_ARGUMENT_ARG };
        _host = RemoteAgentActivator.TryActivate(args);
        _host.OnConnectionChanged += _connectionIndicator.DisplayStatus;
    }

    private void OnDestroy()
    {
        RemoteAgentActivator.Deactivate();
    }
}