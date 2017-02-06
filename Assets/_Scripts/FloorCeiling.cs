using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCeiling : MonoBehaviour {

    public Renderer floorRenderer;
    public Renderer ceilingRenderer;
    public bool fadeIn;

    // Use this for initialization
    void Start()
    {
        fadeIn = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void fadeFloorCeilingOut()
    {
        StartCoroutine(FadeTo(0.0f, 1.0f));
    }

    public void fadeFloorCeilingIn()
    {
        StartCoroutine(FadeTo(1.0f, 5.0f));
        fadeIn = !fadeIn;
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
   
        float alpha1 = floorRenderer.material.color.a;
        float alpha2 = ceilingRenderer.material.color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor0 = new Color(1, 1, 1, Mathf.Lerp(alpha1, aValue, t));
            floorRenderer.material.color = newColor0;
            Color newColor1 = new Color(1, 1, 1, Mathf.Lerp(alpha1, aValue, t));
            ceilingRenderer.material.color = newColor1;
            yield return null;
        }
    }
}
