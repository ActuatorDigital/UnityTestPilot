using UnityEngine;

namespace AIR.Autopilot.Interactions {
    
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
        
        public void SimulateClick (){ }
        public void SimulateClickDown() { }
        public void SimulateClickUp() { }
        public void SimulateKeys(KeyCode[] keys) { }
        public void SimulateKeys(string keys) { }
        
    }
    
}