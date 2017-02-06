using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMenu : MonoBehaviour {

    public Renderer[] childRenders;

    // Use this for initialization
    void Start()
    {
        childRenders = GetComponentsInChildren<Renderer>();

    }

    public void fadePanelOut()
    {
        StartCoroutine(FadeTo(0.0f, 1.0f));
    }

    public void fadePanelIn()
    {
        StartCoroutine(FadeTo(0.647f, 1.0f));
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha1 = childRenders[0].material.color.a;
        float alpha2 = childRenders[1].material.color.a;
        float alpha3 = childRenders[2].material.color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor0 = new Color(1, 1, 1, Mathf.Lerp(alpha1, aValue, t));
            childRenders[0].material.color = newColor0;
            Color newColor1 = new Color(1, 1, 1, Mathf.Lerp(alpha1, aValue, t));
            childRenders[1].material.color = newColor1;
            Color newColor2 = new Color(1, 1, 1, Mathf.Lerp(alpha2, aValue, t));
            childRenders[2].material.color = newColor2;
            yield return null;
        }
    }
}
