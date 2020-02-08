using System.Linq;
using AIR.Autopilot.Interactions;
using UnityEngine;

namespace AIR.UnityPilot.Queries {
    public class NamedElementQuery : ElementQuery {

        private string _queryName;
        
        public NamedElementQuery(string name) {
            _queryName = name;
        }

        public override UiElement[] Search() {

            var elements = GameObject
                .FindObjectsOfType<GameObject>();

            if (elements.Any()) {
                var namedElements = elements
                    .Where(o => o.name == _queryName)
                    .ToArray();
                if(namedElements.Any())
                    return namedElements.Select(o => 
                        new UiElement(o)).ToArray();
            }
            
            return null;
        }
    }
}