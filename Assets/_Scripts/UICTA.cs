using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class UICTA : MonoBehaviour {

    public MainUIPanel mainUIPanel;
    public ModelContainer modelContainer;
    public ModelMenuItem modelMenuItem;
    [SerializeField]
    private AudioSource m_Audio;                                // Reference to the audio source that will play effects when the user looks at it and when it fills.
    [SerializeField]
    private AudioClip m_OnOverClip;                             // The clip to play when the user looks at the bar.
    [SerializeField]
    private AudioClip m_OnFilledClip;                           // The clip to play when the bar finishes filling.
    [SerializeField]
    private SelectionRadial m_SelectionRadial;                  // This controls when the selection is complete.
    [SerializeField]
    private VRInteractiveItem m_InteractiveItem;                // The interactive item for where the user should click to load the level.

    private bool m_GazeOver;                                    // Whether the user is looking at the VRInteractiveItem currently.

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        m_InteractiveItem.OnClick += HandleClick;
    }


    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        m_InteractiveItem.OnClick -= HandleClick;
    }

    private void HandleOver()
    {
        // When the user looks at the rendering of the scene, show the radial.
        m_SelectionRadial.Show();

        m_GazeOver = true;

        // Play the clip appropriate for when the user starts looking at the bar.
        m_Audio.clip = m_OnOverClip;
        m_Audio.Play();
    }


    private void HandleOut()
    {
        // When the user looks away from the rendering of the scene, hide the radial.
        m_SelectionRadial.Hide();

        m_GazeOver = false;
    }

    // Click logic
    public void HandleClick()
    {
        // Play the clip for when the bar is filled.
        m_Audio.clip = m_OnFilledClip;
        m_Audio.Play();
        mainUIPanel.fadeOutPanels();
        modelContainer.setModel(0);
        modelMenuItem.setSceneToLoad(0);
    }


}
