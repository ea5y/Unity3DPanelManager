using UnityEngine;
using System.Collections;

namespace TestUI.System1
{
    public class GUISystem1 : Singleton<GUISystem1>
    {
        void Awake()
        {
            base.Awake();
        }

        [SerializeField]        
        private System1View view;
        public System1View View { get { return this.view; } }


    }
}
