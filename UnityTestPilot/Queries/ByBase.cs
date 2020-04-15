using System;

namespace AIR.UnityTestPilot.Queries {
    public static class ByBase {

        public static ElementQuery Name<TNamedQuery>(string name)
            where TNamedQuery : NamedElementQuery
        {
            var namedQuery = Activator.CreateInstance(typeof(TNamedQuery), name);
            return namedQuery as TNamedQuery;
        }

        public static ElementQuery Type<TQueryType, TTypedQuery>(string name)
            where TTypedQuery : TypedElementQuery
        {
            var typedQuery = Activator.CreateInstance(
                typeof(TTypedQuery),
                typeof(TQueryType), 
                name );
            return typedQuery as TTypedQuery;
        }

        public static ElementQuery Type<TQueryType, TTypedQuery>()
            where TTypedQuery : TypedElementQuery
        {
            var typedQuery = Activator.CreateInstance(
                typeof(TTypedQuery),
                typeof(TQueryType)); 
            return typedQuery as TTypedQuery;
        }
    }
}