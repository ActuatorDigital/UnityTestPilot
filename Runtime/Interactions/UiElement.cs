using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace AIR.UnityTestPilot.Interactions {
    
    public class UiElement {
        
        private readonly Object _object;
        
        public string Name => _object.name;
        
        public bool IsActive {
            get {
                if(_object is MonoBehaviour mgo)
                    return mgo.isActiveAndEnabled;
                if(_object is GameObject go)
                    return go.activeInHierarchy;
                return false;
            }
        }

        public string Text {
            get {
                
                if (_object is Text goText) 
                    return goText.text;
                
                if (_object is MonoBehaviour goMb) {
                    goText = goMb.GetComponent<Text>();
                    if (goText != null)
                        return goText.text;
                }

                if (_object is GameObject go) {
                    goText = go.GetComponent<Text>();
                    if (goText != null)
                        return goText.text;
                }

                return string.Empty;
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

            if (_object is GameObject go) {
                var button = go.GetComponent<Button>();
                if (button != null) {
                    var handlers = button.GetComponents<T>();
                    foreach (var handler in handlers)
                        buttonAction?.Invoke(handler, EventSystem.current);
                }
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