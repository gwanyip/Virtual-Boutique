using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIPanel : MonoBehaviour {

    public UIPanelItem[] uiPanelItems;
    public bool isActive;

	// Use this for initialization
	void Start () {
        isActive = false;
        gameObject.SetActive(isActive);
        uiPanelItems = GetComponentsInChildren<UIPanelItem>();       

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void fadeInPanels() {
        setActiveState();
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
        setActiveState();
    }

    public void setActiveState() {
        isActive = !isActive;
        gameObject.SetActive(isActive);
    }
}
