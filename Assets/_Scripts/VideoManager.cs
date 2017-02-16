using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;

public class VideoManager : MonoBehaviour {

    [SerializeField] private float m_IntroOutroFadeDuration = 2f;                     // The duration of the fade before and after the intro
    [SerializeField] private UIControllerVB m_UIController;                           // This needs to know when specific pieces of UI should be shown.
    [SerializeField] private VRCameraFade m_CameraFade;                               // This is used to fade out and back in again as the game starts.
    [SerializeField] private MediaPlayerCtrl m_360VideoCtrl;                          // This is used to fade out and back in again as the game starts.
    [SerializeField] private SelectionRadial m_SelectionRadial;                       // Selection Radial

    public GameObject m_Button1;
    public GameObject m_Button2;

    // Use this for initialization
    void Start () {

        m_360VideoCtrl.OnReady += OnReady;
        m_360VideoCtrl.OnEnd += OnEnd;
         
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnReady()
    {
        Debug.Log("Video has started");
        m_Button1.SetActive(false);
        m_Button2.SetActive(false);
        m_SelectionRadial.Hide();
    }

    void OnEnd() {
        Debug.Log("Video has finished");
        m_Button1.SetActive(true);
        m_Button2.SetActive(true);
        m_SelectionRadial.Show();
        StartCoroutine(StartPhase());
    }

    private IEnumerator StartPhase()
    {
        // Make sure the Outro UI is not being shown and the intro UI is.
        StartCoroutine(m_UIController.ShowIntroUI());

        // Turn off the fog whilst showing the intro.
        RenderSettings.fog = false;

        // In order wait for the selection slider to fill, then the intro UI to hide, then the camera to fade out.
        //yield return StartCoroutine(m_UIController.HideIntroUI());
        // yield return StartCoroutine(m_CameraFade.BeginFadeOut(m_IntroOutroFadeDuration, false));

        // Turn the fog back on so spawned objects won't appear suddenly.
        RenderSettings.fog = true;

        // Now wait for the screen to fade back in.
        yield return StartCoroutine(m_CameraFade.BeginFadeIn(m_IntroOutroFadeDuration, false));
    }

    private IEnumerator EndPhase()
    {
        // Wait for the camera to fade out.
        yield return StartCoroutine(m_CameraFade.BeginFadeOut(m_IntroOutroFadeDuration, false));

        // Turn off the fog.
        RenderSettings.fog = false;

        // Show the outro UI.
        StartCoroutine(m_UIController.ShowOutroUI());

        // In order, wait for the screen to fade in, then wait for the user to fill the radial.
        yield return StartCoroutine(m_CameraFade.BeginFadeIn(m_IntroOutroFadeDuration, false));

        // Wait for the outro UI to hide.
        yield return StartCoroutine(m_UIController.HideOutroUI());

        // Turn the fog back on.
        RenderSettings.fog = true;
    }
}
