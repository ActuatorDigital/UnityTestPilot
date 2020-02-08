using System;
using System.Collections;
using System.Threading.Tasks;
using AIR.Autopilot.Interactions;
using UnityEngine;

namespace AIR.UnityPilot.Drivers {
    
    public class UnityDriverWait {
        
        private float _timeout;
        private UnityDriver _driver;

        public UnityDriverWait(UnityDriver driver, TimeSpan timeout) {
            _timeout = Time.time + (float)timeout.TotalSeconds;
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
            } while (Time.time < _timeout);
        }

        public Task<UiElement> Until(Func<UnityDriver, UiElement> until) {
            return null;
        }

        public UiElement UntilSync(Func<UnityDriver, UiElement> until) {
            return null;
        }
        
    }
    
}