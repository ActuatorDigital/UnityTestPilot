using AIR.UnityPilot.Queries;

namespace AIR.UnityPilot {
    public static class By {

        public static ElementQuery Name(string name) {
            return new NamedElementQuery(name);
        }

        public static ElementQuery TypeWithName<T>(string name) {
            return new TypedElementQuery(typeof(T), name);
        }

        public static ElementQuery Type<T>() {
            return new TypedElementQuery(typeof(T));
        }
    }
}