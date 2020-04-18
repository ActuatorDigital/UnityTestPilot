namespace AIR.UnityTestPilot.Queries
{
    public abstract class NamedElementQuery : ElementQuery
    {
        public readonly string NameToFind;

        protected NamedElementQuery(string nameToFind) => NameToFind = nameToFind;
    }
}