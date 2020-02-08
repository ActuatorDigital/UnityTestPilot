using AIR.Autopilot.Interactions;

namespace AIR.UnityPilot.Queries {
    
    public abstract class ElementQuery {
        
        private UiElement[] _foundElement;

        public abstract UiElement[] Search();

    }
    
}