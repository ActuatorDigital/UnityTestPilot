// Copyright (c) AIR Pty Ltd. All rights reserved.

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DelayedClickCounter : MonoBehaviour
{
    private int _spawnedTextsCount = 0;
    [SerializeField] private VerticalLayoutGroup _layout = null;
    [SerializeField] private Text _lateEffectTextPrefab = null;
    [SerializeField] private Text _nextButtonCounter = null;

    public void HandleDelayedCounterClicked()
    {
        _nextButtonCounter.text = "Spawn Text " + (_spawnedTextsCount++);
        StartCoroutine(ClickFeedbackDelayed(_spawnedTextsCount));
    }

    private IEnumerator ClickFeedbackDelayed(int nextCounter)
    {
        yield return new WaitForSeconds(1f);
        var text = Instantiate(_lateEffectTextPrefab, _layout.transform, false);
        text.text = "Late effect " + nextCounter;
        text.gameObject.name = "DelayedEffect_Text_" + nextCounter;
    }
}