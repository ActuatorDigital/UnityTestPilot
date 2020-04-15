namespace AIR.UnityTestPilot.Interactions
{
    public abstract class UiElement
    {
        protected readonly object _object;
        protected UiElement(object obj) => _object = obj;

        public abstract string Name { get; }
        public abstract bool IsActive { get; }
        public abstract string Text { get; }
        public abstract void MiddleClick();
        public abstract void RightClick();
        public abstract void LeftClick();
        public abstract void LeftClickDown();
        public abstract void RightClickDown();
        public abstract void MiddleClickDown();
        public abstract void LeftClickUp();
        public abstract void RightClickUp();
        public abstract void MiddleClickUp();
        public abstract void SimulateKeys(KeyCode[] keys);
        public abstract void SimulateKeys(string keys);
    }
}