using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelManager : Singleton<PanelManager>
{
    private List<GameObject> layerBottom = new List<GameObject>();
    private List<GameObject> layerMiddle = new List<GameObject>();
    private List<GameObject> layerTop = new List<GameObject>();

    [SerializeField]
    private List<GameObject> layerList = new List<GameObject>();

    public void Remove(GameObject view)
    {
        PanelManager.Instance.layerList.Remove(view);
    }

    static public void Open(GameObject view, bool isMutex)
    {
        if (view.activeSelf == false)
        {
            //if mutex
            if (isMutex)
            {
                if (PanelManager.Instance.layerList.Count != 0)
                {
                    PanelManager.Instance.layerList.RemoveAt(PanelManager.Instance.layerList.Count - 1);
                }

                view.gameObject.SetActive(true);
                PanelManager.Instance.layerList.Add(view);
            }
            else
            {
                view.gameObject.SetActive(true);
                PanelManager.Instance.layerList.Add(view);
            }
        }
        
    }

    static public void Open(GameObject view, bool isMutex, bool prevHide)
    {
        if (view.activeSelf == false)
        {
            //if mutex
            if (isMutex)
            {
                if (PanelManager.Instance.layerList.Count != 0)
                {
                    PanelManager.Instance.layerList[PanelManager.Instance.layerList.Count - 1].SetActive(false);
                    PanelManager.Instance.layerList.RemoveAt(PanelManager.Instance.layerList.Count - 1);
                }

                view.gameObject.SetActive(true);
                PanelManager.Instance.layerList.Add(view);
            }
            else
            {
                if (prevHide)
                {
                    PanelManager.Instance.layerList[PanelManager.Instance.layerList.Count - 1].SetActive(false);
                }
                view.gameObject.SetActive(true);
                PanelManager.Instance.layerList.Add(view);
            }
        }

    }

    static public void Close(GameObject view)
    {
        view.gameObject.SetActive(false);
        /*var cl = PanelManager.layerList.Find(x => {
            if (x = view)
            {
                return true;
            }
            else
            {
                return false;
            } 
        });*/
        PanelManager.Instance.layerList.Remove(view);
    }

    static public void Back()
    {
        if (PanelManager.Instance.layerList.Count == 0)
            return;
        PanelManager.Instance.layerList[PanelManager.Instance.layerList.Count - 1].SetActive(false);
        PanelManager.Instance.layerList.RemoveAt(PanelManager.Instance.layerList.Count - 1);
        if (PanelManager.Instance.layerList.Count == 0)
            return;
        if (PanelManager.Instance.layerList[PanelManager.Instance.layerList.Count - 1].activeSelf == false)
            PanelManager.Instance.layerList[PanelManager.Instance.layerList.Count - 1].SetActive(true);
    }

    static public void Home(GameObject root)
    {

    }
}
