using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelItem : MonoBehaviour {

    public Renderer backPanel;
    public Renderer cta;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void fadePanelOut() {
        StartCoroutine(FadeTo(0.0f, 1.0f));
    }

    public void fadePanelIn()
    {
        StartCoroutine(FadeTo(1.0f, 1.0f));
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {

        float alpha1 = backPanel.material.color.a;
        float alpha2 = cta.material.color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor0 = new Color(1, 1, 1, Mathf.Lerp(alpha1, aValue, t));
            backPanel.material.color = newColor0;
            Color newColor1 = new Color(1, 1, 1, Mathf.Lerp(alpha1, aValue, t));
            cta.material.color = newColor1;
            yield return null;
        }
    }
}
