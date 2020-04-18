using System;
using System.Linq;
using AIR.UnityTestPilot.Agents;
using AIR.UnityTestPilot.Interactions;
using AIR.UnityTestPilot.Queries;

namespace AIR.UnityTestPilot.Drivers {
    
    public class UnityDriver : IDisposable {
        
        private readonly IUnityDriverAgent _agent;

        public UnityDriver(IUnityDriverAgent agent) => _agent = agent;

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

        public void Dispose() => _agent.Shutdown();
    }
    
}