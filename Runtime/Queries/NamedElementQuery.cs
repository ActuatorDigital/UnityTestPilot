namespace AIR.UnityTestPilot.Queries
{
    public abstract class NamedElementQuery : ElementQuery
    {
        protected readonly string _queryName;

        protected NamedElementQuery(string name) {
            _queryName = name;
        }
        
    }
}