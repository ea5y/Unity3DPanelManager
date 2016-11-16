using UnityEngine;
using System.Collections;
using CustomControl;

namespace TestUI.System1
{
    [System.Serializable]
    public class UIView2 : IPageView
    {
        public GameObject root;
        public GameObject Root { get { return this.root; } }

        public UIButton btnChild1;
        public UIButton btnChild2;

        [SerializeField]
        private View2Child1 child1;
        public View2Child1 Chilld1 { get { return this.child1; } }
        [System.Serializable]
        public class View2Child1 : UIViewBase
        {
            public GameObject root;
        }

        [SerializeField]
        private View2Child2 child2;
        public View2Child2 Chilld2 { get { return this.child2; } }
        [System.Serializable]
        public class View2Child2 : UIViewBase
        {
            public GameObject root;
        }

        public void Init()
        {
            if (this.Chilld1.root.activeSelf == true)
            {
                this.Chilld1.root.SetActive(false);
                PanelManager.Instance.Remove(this.Chilld1.root);
            }

            if (this.Chilld2.root.activeSelf == true)
            {
                this.Chilld2.root.SetActive(false);
                PanelManager.Instance.Remove(this.Chilld2.root);
            }
        }
    }

}
