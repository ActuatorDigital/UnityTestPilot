using AIR.Autopilot.Interactions;
using AIR.UnityPilot.Queries;

namespace AIR.UnityPilot.Agents {
    
    class ClientUnityDriverAgent : IUnityDriverAgent {
        
        private NativeUnityDriverAgent _nativeDriver;

        public void SetTimeScale(float timeScale) {
            _nativeDriver.SetTimeScale(timeScale);
        }
        
        public void Shutdown() {
            _nativeDriver.Shutdown();
        }
        
        public UiElement[] Query(ElementQuery query) {
            return _nativeDriver.Query(query);
        }
    }
    
}