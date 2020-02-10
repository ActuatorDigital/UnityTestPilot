using System;
using System.Linq;
using AIR.UnityTestPilot.Interactions;

namespace AIR.UnityTestPilot.Queries {
    public class TypedElementQuery : ElementQuery {

        private Type _queryType;
        private string _queryName;
        
        public TypedElementQuery(Type type, string name) {
            _queryType = type;
            _queryName = name;
        }

        public TypedElementQuery(Type type) {
            _queryType = type;
        }

        public override UiElement[] Search() {
            var hits = UnityEngine.Object
                .FindObjectsOfType(_queryType)
                .ToArray();

            if (!hits.Any())
                return null;
            
            if (_queryName != null)
                hits = hits
                    .Where(h => h.name == _queryName)
                    .ToArray();

            if (hits.Any())
                return hits
                    .Select(h => new UiElement(h))
                    .ToArray();

            return null;
        }
    }
}