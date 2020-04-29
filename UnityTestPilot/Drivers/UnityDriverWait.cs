using System;
using System.Collections;
using System.Reflection;
using System.Threading.Tasks;
using AIR.UnityTestPilot.Interactions;

namespace AIR.UnityTestPilot.Drivers {
    
    public class UnityDriverWait {
        
        private readonly DateTime _timeout;
        private readonly UnityDriver _driver;

        public UnityDriverWait(UnityDriver driver, TimeSpan timeout) {
            _timeout = DateTime.Now + timeout;
            _driver = driver;
        }

        public void Until(Func<UnityDriver, bool> until)
            => until?.Invoke(_driver);

        public IEnumerator Until(
            Func<UnityDriver, UiElement> until, 
            Action<UiElement> onFound
        ) {
            do {
                var uiElement = until.Invoke(_driver);
                if (uiElement == null) {
                    yield return null;
                } else {
                    onFound(uiElement);
                    break;
                }
            } while (DateTime.Now < _timeout);
        }

        public Task<UiElement> Until(Func<UnityDriver, UiElement> until) 
            => Task.Run( () => {
                UiElement element = null;
                while( element == null || DateTime.Now < _timeout)
                    element = until?.Invoke(_driver);
                return element;
            });

        public UiElement UntilSync(Func<UnityDriver, UiElement> until) 
            => until?.Invoke(_driver);
    }
    
}