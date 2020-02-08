using AIR.Autopilot.Interactions;
using AIR.UnityPilot.Queries;

namespace AIR.UnityPilot.Agents {
    public interface IUnityDriverAgent {
        UiElement[] Query(ElementQuery query);
        void Shutdown();
        void SetTimeScale(float timeScale);
    }
}