using AIR.UnityTestPilot.Interactions;

namespace AIR.UnityTestPilot.Queries {
    
    public abstract class ElementQuery {
        
        private UiElement[] _foundElement;

        public abstract UiElement[] Search();

    }
    
}