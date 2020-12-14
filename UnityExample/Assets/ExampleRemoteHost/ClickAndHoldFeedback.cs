// Copyright (c) AIR Pty Ltd. All rights reserved.

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickAndHoldFeedback : MonoBehaviour
{
    [SerializeField] private Text _heldText = null;

    Coroutine _heldRoutine;

    public void HandleClickDown() {
        _heldRoutine = StartCoroutine(ShowHeldTime());
    }

    private IEnumerator ShowHeldTime()
    {
        float time = 0;
        while (true) {
            time += Time.deltaTime;
            _heldText.text = time.ToString();
            yield return null;
        }
    }

    public void HandleClickUp()
    {
        StopCoroutine(_heldRoutine);
        _heldText.text = "Released";
    }

}