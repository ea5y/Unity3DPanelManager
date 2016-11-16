using UnityEngine;
using System.Collections;

namespace TestUI.System1
{
    [System.Serializable]
    public class UIView1
    {
        public GameObject root;
        public UIButton btnChild1;
        public UIButton btnChild2;

        [SerializeField]
        private View1Child1 child1;
        public View1Child1 Chilld1 { get { return this.child1; } }
        [System.Serializable]
        public class View1Child1 : UIViewBase
        {
            public GameObject root;
        }

        [SerializeField]
        private View1Child2 child2;
        public View1Child2 Chilld2 { get { return this.child2; } }
        [System.Serializable]
        public class View1Child2 : UIViewBase
        {
            public GameObject root;
        }
    }

}
