using AIR.UnityTestPilot.Interactions;
using AIR.UnityTestPilot.Queries;

namespace AIR.UnityTestPilot.Agents {
    public interface IUnityDriverAgent {
        UiElement[] Query(ElementQuery query);
        void Shutdown();
        void SetTimeScale(float timeScale);
    }
}