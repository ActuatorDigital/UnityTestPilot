using System;
using System.Linq;
using AIR.Autopilot.Interactions;
using AIR.UnityPilot.Agents;
using AIR.UnityPilot.Queries;

namespace AIR.UnityPilot.Drivers {
    
    public class UnityDriver : IDisposable {
        
        private IUnityDriverAgent _agent;

        public UnityDriver(IUnityDriverAgent agent) {
            _agent = agent;
        }

        public UiElement FindElement(ElementQuery query) {
            var elements = FindElements(query); 
            if(elements != null && elements.Any())
                return elements.FirstOrDefault();
            return null;
        }
        
        public UiElement[] FindElements(ElementQuery query) {
            var element = _agent.Query(query);
            return element;
        }

        public void Dispose() {
            _agent.Shutdown();
        }

    }
    
}