namespace AIR.UnityTestPilot.Queries {
    public static class By {

        public static ElementQuery Name(string name) {
            return new NamedElementQuery(name);
        }

        public static ElementQuery Type<T>(string name) {
            return new TypedElementQuery(typeof(T), name);
        }

        public static ElementQuery Type<T>() {
            return new TypedElementQuery(typeof(T));
        }
    }
}