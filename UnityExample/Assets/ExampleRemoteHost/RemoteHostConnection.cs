// Copyright (c) AIR Pty Ltd. All rights reserved.

using AIR.UnityTestPilotRemote.Host;
using UnityEngine;

public class RemoteHostConnection : MonoBehaviour
{
    private RemoteUnityAgentHost _host;
    [SerializeField] private ConnectionStatusIndicator _connectionIndicator = null;

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