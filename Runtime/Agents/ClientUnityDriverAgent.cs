using AIR.UnityTestPilot.Interactions;
using AIR.UnityTestPilot.Queries;

namespace AIR.UnityTestPilot.Agents {
    
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