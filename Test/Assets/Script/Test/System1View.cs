using UnityEngine;
using System.Collections;

namespace TestUI.System1
{
    [System.Serializable]
    public class System1View : UIViewBase
    {
        //root
        public GameObject _root;

        //base
        [SerializeField]
        private TestUI.System1.UIBase _base;
        public TestUI.System1.UIBase Base { get { return this._base; } }

        //view1
        [SerializeField]
        private TestUI.System1.UIView1 _view1;
        public TestUI.System1.UIView1 View1 { get { return this._view1; } }

        //view2
        [SerializeField]
        private TestUI.System1.UIView2 _view2;
        public TestUI.System1.UIView2 View2 { get { return this._view2; } }

        //view3
        [SerializeField]
        private TestUI.System1.UIView3 _view3;
        public TestUI.System1.UIView3 View3 { get { return this._view3; } }
    }
}

