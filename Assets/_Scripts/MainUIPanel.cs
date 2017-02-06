using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIPanel : MonoBehaviour {

    public UIPanelItem[] uiPanelItems; 

	// Use this for initialization
	void Start () {
        uiPanelItems = GetComponentsInChildren<UIPanelItem>();       

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void fadeInPanels() {
        for (int i = 0; i < uiPanelItems.Length; i++) {
            uiPanelItems[i].fadePanelIn();        
        }
    }

    public void fadeOutPanels()
    {
        for (int i = 0; i < uiPanelItems.Length; i++)
        {
            uiPanelItems[i].fadePanelOut();
        }
    }
}
