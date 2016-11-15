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

    public class PanelManager
    {
        private List<GameObject> layerBottom = new List<GameObject>();
        private List<GameObject> layerMiddle = new List<GameObject>();
        private List<GameObject> layerTop = new List<GameObject>();

        static public void Open(object view)
        {
            
        }

        static public void Close()
        {

        }

        static public void Back()
        {

        }

        static public void Home()
        {

        }
    }
}
