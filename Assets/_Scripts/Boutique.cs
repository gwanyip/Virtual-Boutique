using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Boutique : MonoBehaviour {

    public Building building;
    public MainUIPanel mainUIPanel;
    public float windowFade = 10f;
    public GameObject window1;
    public GameObject window2;
    public GameObject window3;

    [SerializeField] private AudioSource m_Audio;                                  // Reference to the audio source that will play effects when the user looks at it and when it fills.
    [SerializeField] private AudioClip m_EntranceClip;                             // The clip to play when the boutique materializes
    [SerializeField] private SelectionRadial m_SelectionRadial;                    // Selection Radial

    // Use this for initialization
    void Start () {
        removeWindows();
        m_Audio.clip = m_EntranceClip;
        m_SelectionRadial.Hide();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > 5f && Time.timeSinceLevelLoad < 5.5f) {
            building.fadeInFloorCeiling();
            m_Audio.Play();
        }
        if (Time.timeSinceLevelLoad > 11f && Time.timeSinceLevelLoad < 11.5f)
        {
            addWindows();
        }
        if (Time.timeSinceLevelLoad > 14f && Time.timeSinceLevelLoad < 14f + Time.deltaTime) {
            m_SelectionRadial.Hide();
            mainUIPanel.fadeInPanels();
        }
    }

    public void removeWindows() {
        window1.transform.localScale = new Vector3(window1.transform.localScale.x, 0f, window1.transform.localScale.z);
        window2.transform.localScale = new Vector3(window2.transform.localScale.x, 0f, window2.transform.localScale.z);
        window3.transform.localScale = new Vector3(window3.transform.localScale.x, 0f, window3.transform.localScale.z);
    }

    public void addWindows()
    {
        var windowScale = new Vector3(window1.transform.localScale.x, 14.7f, window1.transform.localScale.z);
        var windowScale3 = new Vector3(window3.transform.localScale.x, 14.7f, window3.transform.localScale.z);
        window1.transform.localScale = Vector3.Lerp(window1.transform.localScale, windowScale, Time.deltaTime * windowFade);
        window2.transform.localScale = Vector3.Lerp(window2.transform.localScale, windowScale, Time.deltaTime * windowFade);
        window3.transform.localScale = Vector3.Lerp(window3.transform.localScale, windowScale3, Time.deltaTime * windowFade);
    }
}
