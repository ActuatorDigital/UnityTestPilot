using System;
using System.Collections;
using System.Threading.Tasks;
using AIR.UnityTestPilot.Interactions;

namespace AIR.UnityTestPilot.Drivers {
    
    public class UnityDriverWait {
        
        private DateTime _timeout;
        private UnityDriver _driver;

        public UnityDriverWait(UnityDriver driver, TimeSpan timeout) {
            _timeout = DateTime.Now + timeout;
            _driver = driver;
        }
        
        public void Until(Func<UnityDriver, bool> until){ }

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

        public Task<UiElement> Until(Func<UnityDriver, UiElement> until) {
            throw new NotImplementedException("Wait until found in task.");
        }

        public UiElement UntilSync(Func<UnityDriver, UiElement> until) {
            throw new NotImplementedException("Sync hold until task result.");
        }
        
    }
    
}