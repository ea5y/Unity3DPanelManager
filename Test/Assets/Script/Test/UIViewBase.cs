using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TestUI {
    public enum LayerIndex 
    {
        Bottom,
        Middle,
        Top
    }
    public class UIViewBase
    {
        /// <summary> 
        /// Property
        /// </summary>
        public LayerIndex _layerIndex = LayerIndex.Middle;
        public GameObject _parent; 
        public bool _isMutex = true;
    }

    
}
