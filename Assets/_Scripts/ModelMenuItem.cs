using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

public class ModelMenuItem : MonoBehaviour {

    public bool m_PlayPause;                                                    // Establish if this is for the Play/Pause button
    public bool m_PlayVideo;                                                    // Establish if this is for the Play Video button
    public bool m_ReturnMenu;                                                   // Establish if this is for the Return Menu button

    public bool m_RadialCTA;                                                    // Signify if the CTA is a radial
    public bool m_ClickCTA;                                                     // Signify if the CTA is a click

    public ModelContainer m_ModelContainer;                                     // Model container
    public string[] m_Scenes;                                                   // Array of videos to load
    public string m_SceneToLoad;                                                // Active scene to load

    public ModelMenu m_ModelMenu;                                               // Model Menu to fade out on return
    public ModelControllers m_ModelControllers;                                 // Model Controllers to Fade Out

    [SerializeField] private AudioSource m_Audio;                                // Reference to the audio source that will play effects when the user looks at it and when it fills.
    [SerializeField] private AudioClip m_OnOverClip;                             // The clip to play when the user looks at the bar.
    [SerializeField] private AudioClip m_OnClick;                                // The clip to play when the user looks at the bar.
    [SerializeField] private AudioClip m_OnFilledClip;                           // The clip to play when the bar finishes filling.

    [SerializeField] private VRCameraFade m_CameraFade;                         // This fades the scene out when a new scene is about to be loaded.
    [SerializeField] private SelectionRadial m_SelectionRadial;                 // This controls when the selection is complete.
    [SerializeField] private VRInteractiveItem m_InteractiveItem;               // The interactive item for where the user should click to load the level.

    private bool m_GazeOver;                                                    // Whether the user is looking at the VRInteractiveItem currently.

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Code that manages the type of reticle depending on the UI item
        private void OnEnable()
        {
            if (m_RadialCTA)
            {
                m_InteractiveItem.OnOver += HandleOver;
                m_InteractiveItem.OnOut += HandleOut;
                m_InteractiveItem.OnClick += HandleClick;
            }
            else if (m_ClickCTA) {
                m_InteractiveItem.OnClick += HandleClick;
            }
        }


        private void OnDisable()
        {
            if (m_RadialCTA)
            {
                m_InteractiveItem.OnOver -= HandleOver;
                m_InteractiveItem.OnOut -= HandleOut;
                m_InteractiveItem.OnClick -= HandleClick;
            }
            else if (m_ClickCTA)
            {
                m_InteractiveItem.OnClick -= HandleClick;
            }
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


    // Play and Pause Model rotation
        public void PlayPauseRotation() {
            m_ModelContainer.playPauseRotate();
        }

    // Play Video [Video 1 or Video 2]
        public void setSceneToLoad(int index) {
            m_SceneToLoad = m_Scenes[index];
        }

        private IEnumerator ActivateButton(string scene)
        {

            // If the camera is already fading, ignore.
            if (m_CameraFade.IsFading)
                yield break;

            // Wait for the camera to fade out.
            yield return StartCoroutine(m_CameraFade.BeginFadeOut(true));

            // Load the level.
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }

    // Return to Main UI
    public void returnToMainMenu() {
        // Fade out model container
        m_ModelContainer.exitAnimation();
    }

    // Click logic
    public void HandleClick() {
        if (m_PlayPause)
        {
            // Play the clip appropriate for when the user starts looking at the bar.
            m_Audio.clip = m_OnClick;
            m_Audio.Play();

            PlayPauseRotation();
            // if (!m_ModelControllers.isActive) {
            //    m_ModelControllers.fadePanelIn();
            // }
        }
        else if (m_PlayVideo) {
            // Play the clip appropriate for when the user starts looking at the bar.
            m_Audio.clip = m_OnFilledClip;
            m_Audio.Play();

            StartCoroutine(ActivateButton(m_SceneToLoad));
        }
        else if (m_ReturnMenu && m_GazeOver)
        {
            // Play the clip appropriate for when the user starts looking at the bar.
            m_Audio.clip = m_OnFilledClip;
            m_Audio.Play();

            returnToMainMenu();
        }
    }

}
