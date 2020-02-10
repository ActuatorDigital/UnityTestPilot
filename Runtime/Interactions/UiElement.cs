using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;

namespace AIR.UnityTestPilot.Interactions {
    
    public class UiElement {
        
        private readonly Object _object;
        
        public string Name => _object.name;
        
        public bool ActiveInHierarchy {
            get {
                if(_object is GameObject mgo)
                    return mgo.activeInHierarchy;
                return false;
            }
        }
        
        public UiElement(Object obj) {
            _object = obj;
        }

        public void MiddleClick() => SimulateClick(PointerEventData.InputButton.Middle);
        public void RightClick() => SimulateClick(PointerEventData.InputButton.Right);
        public void LeftClick() => SimulateClick(PointerEventData.InputButton.Left);
        public void LeftClickDown() => SimulateClickDown(PointerEventData.InputButton.Left);
        public void RightClickDown() => SimulateClickDown(PointerEventData.InputButton.Right);
        public void MiddleClickDown() => SimulateClickDown(PointerEventData.InputButton.Middle);
        public void LeftClickUp() => SimulateClickUp(PointerEventData.InputButton.Left);
        public void RightClickUp() => SimulateClickUp(PointerEventData.InputButton.Right);
        public void MiddleClickUp() => SimulateClickUp(PointerEventData.InputButton.Middle);
        private void SimulateClick(PointerEventData.InputButton mouseButton) {
            ButtonEventInvoke<IPointerClickHandler>((b, es) => 
                b.OnPointerClick( new PointerEventData(es) { button = mouseButton } ));
        }

        private void SimulateClickDown(PointerEventData.InputButton mouseButton) {
            ButtonEventInvoke<IPointerDownHandler>((b, es) => 
                b.OnPointerDown( new PointerEventData(es) { button = mouseButton } ));
        }

        private void SimulateClickUp(PointerEventData.InputButton mouseButton) {
            ButtonEventInvoke<IPointerUpHandler>((b, es) => 
                b.OnPointerUp( new PointerEventData(es) { button = mouseButton } ));
        }

        private void ButtonEventInvoke<T>(Action<T, EventSystem> buttonAction) {
            if (_object is MonoBehaviour mb) {
                var handlers = mb.GetComponents<T>();
                foreach (var handler in handlers)
                    buttonAction?.Invoke(handler, EventSystem.current);
            }
        } 

        public void SimulateKeys(KeyCode[] keys) {
            throw new NotImplementedException("Send keys to unity input system.");
        }

        public void SimulateKeys(string keys) {
            throw new NotImplementedException("Convert string to keys then call SimulateKeys.");
        }
    }
    
}