using System;
using AIR.UnityTestPilot.Interactions;
using AIR.UnityTestPilot.Queries;

namespace AIR.UnityTestPilot.Agents {
    class RemoteUnityDriverAgent : IUnityDriverAgent {
        
        public async void Shutdown() {
            throw new NotImplementedException(
                "Call ClientUnityDriver over tachyon.");
        }

        public void SetTimeScale(float timeScale) {
            throw new NotImplementedException(
                "Call ClientDriver over tachyon.");
        }

        public UiElement[] Query(ElementQuery query) {
            throw new NotImplementedException(
                "Call ClientUnityDriver over tachyon.");
        }
    }
}