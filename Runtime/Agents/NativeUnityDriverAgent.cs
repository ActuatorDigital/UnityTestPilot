using System;
using AIR.Autopilot.Interactions;
using AIR.UnityPilot.Queries;
using UnityEngine;

namespace AIR.UnityPilot.Agents {
    public class NativeUnityDriverAgent : IUnityDriverAgent {
        
        public void Shutdown() {
            #if !UNITY_EDITOR
            Application.Quit();
            #endif
        }

        public void SetTimeScale(float timeScale) {
            throw new NotImplementedException(
                "Change Time.timeScale for faster test replay.");
            Time.timeScale = timeScale;
        }

        public UiElement[] Query(ElementQuery query) {
            return query.Search();
        }

    }
}