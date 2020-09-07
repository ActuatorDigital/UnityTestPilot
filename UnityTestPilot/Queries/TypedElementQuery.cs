using System;
using AIR.UnityTestPilot.Interactions;

namespace AIR.UnityTestPilot.Queries {
    public abstract class TypedElementQuery : ElementQuery {

        protected readonly Type _queryType;
        protected readonly string _queryName;
        
        public TypedElementQuery(Type type, string name) {
            _queryType = type;
            _queryName = name;
        }

        public TypedElementQuery(Type type) => _queryType = type;

        public abstract override UiElement[] Search();
    }
}