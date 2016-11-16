using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CustomControl;

namespace TestUI.System1
{
    public class GUISystem1 : Singleton<GUISystem1>
    {
        TabPagesManager pages;
        TabPagesManager Pages { get { return this.pages; } set { this.pages = value; } }

        void Awake()
        {
            base.Awake();
            this.Init();
        }

        [SerializeField]        
        private System1View view;
        public System1View View { get { return this.view; } }

        void Init()
        {
            this.InitView1();
            this.InitView2();
            this.InitView3();

            this.Pages = new TabPagesManager();

            Pages.AddPage(View.View1 as IPageView);
            Pages.AddPage(View.View2 as IPageView);
            Pages.AddPage(View.View3 as IPageView);

            Pages.SwitchTo(View.View1 as IPageView);
            this.View._root.SetActive(false);

            EventDelegate.Add(View.Base.btnTab1.onClick, this.OnTab1Click);
            EventDelegate.Add(View.Base.btnTab2.onClick, this.OnTab2Click);
            EventDelegate.Add(View.Base.btnTab3.onClick, this.OnTab3Click);
        }

        void InitView1()
        {
            View.View1.Chilld1.root.SetActive(false);
            View.View1.Chilld2.root.SetActive(false);
        }

        void InitView2()
        {
            View.View2.Chilld1.root.SetActive(false);
            View.View2.Chilld2.root.SetActive(false);
        }

        void InitView3()
        {
            View.View3.Chilld1.root.SetActive(false);
            View.View3.Chilld2.root.SetActive(false);
        }

        public void SwitchTo(IPageView view)
        {
            Pages.SwitchTo(view);
        }

        public void OnView1Btn1Click()
        {
            PanelManager.Open(View.View1.Chilld1.root, false);
        }
        public void OnView1Btn2Click()
        {
            PanelManager.Open(View.View1.Chilld2.root, false);
        }

        public void OnView2Btn1Click()
        {
            PanelManager.Open(View.View2.Chilld1.root, false);
        }
        public void OnView2Btn2Click()
        {
            PanelManager.Open(View.View2.Chilld2.root, false);
        }

        public void OnView3Btn1Click()
        {
            PanelManager.Open(View.View3.Chilld1.root, false);
        }
        public void OnView3Btn2Click()
        {
            PanelManager.Open(View.View3.Chilld2.root, false);
        }

        public void OnBackClick()
        {
            PanelManager.Back();
        }

        public void OnHomeClick()
        {
            PanelManager.Home(View._root);
        }

        public void OnTab1Click()
        {
            this.SwitchTo(View.View1 as IPageView);
        }

        public void OnTab2Click()
        {
            this.SwitchTo(View.View2 as IPageView);
        }

        public void OnTab3Click()
        {
            this.SwitchTo(View.View3 as IPageView);
        }
    }

    
}

namespace CustomControl
{
    public interface IPageView
    {
        GameObject Root { get; }
        void Init();
    }


    public class TabPagesManager
    {
        private List<IPageView> pages = new List<IPageView>();

        public TabPagesManager()
        {

        }

        public TabPagesManager(IPageView[] pages)
        {
            for (int i = 0; i < pages.Length; i++)
            {
                this.pages.Add(pages[i]);
            }
        }


        public void AddPage(IPageView page)
        {
            this.pages.Add(page);
        }

        public void SwitchTo(IPageView view)
        {
            foreach (var page in this.pages)
            {
                if (view == page)
                {
                    page.Root.SetActive(true);
                }
                else
                {
                    page.Init();
                    page.Root.SetActive(false);
                }

            }
        }
    }
}