namespace AIR.UnityTestPilot.Queries
{
    public abstract class PathElementQuery : ElementQuery
    {
        public readonly string PathToFind;

        protected PathElementQuery(string pathToFind) => PathToFind = pathToFind;
    }
}