using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelContainer : MonoBehaviour {

    public float rotateDistance = 1.5f;
    public float rotatationSpeed = 5f;
    public bool rotRight = false;
    public bool rotLeft = false;
    public GameObject[] Models;
    public GameObject activeModel;
    public ParticleSystem warpIn;
    public Component[] fadeMaterial;
    public FadeMaterial podium;
    public ModelControllers modelControllers;
    public ModelMenu modelMenu;
    public MainUIPanel mainUIPanel;                                           // Main UI Panel to fade back in on return
    [SerializeField]
    private AudioSource m_Audio;                                              // Reference to the audio source that will play effects when the user looks at it and when it fills.
    [SerializeField]
    private AudioClip m_ModelGeneration;                                      // The clip to play when the user looks at the bar.

    private bool playPause = false;

    // Use this for initialization
    void Start () {
        // Set default active model to 0
        activeModel = Models[0];
        // Play the clip appropriate for when the user starts looking at the bar.
        m_Audio.clip = m_ModelGeneration;
        if (warpIn.isPlaying){
            warpIn.Stop();
        };

    }

    // Fade model materials in
    public void fadeInMaterials() {
        foreach (FadeMaterial fade in fadeMaterial)
        {
            fade.FadeIn();
        }
    }
    // Fade model materials out
    public void fadeOutMaterials()
    {
        foreach (FadeMaterial fade in fadeMaterial)
        {
            fade.FadeOut();
        }
    }

    // Entrance animation
    public void entranceAnimation()
    {
        StartCoroutine(ModelEntrance());
    }

    IEnumerator ModelEntrance()
    {
        podium.FadeIn();
        warpIn.Play();
        yield return new WaitForSeconds(2);
        m_Audio.Play();
        yield return new WaitForSeconds(5); 
        fadeInMaterials();
        // modelControllers.fadePanelIn();
        modelMenu.fadePanelIn();
        warpIn.Stop();
        yield return new WaitForSeconds(3);
        m_Audio.Stop();
    }

    // Exit animation
    public void exitAnimation()
    {
        StartCoroutine(ModelExit());
    }

    IEnumerator ModelExit()
    {
        warpIn.Play();
        yield return new WaitForSeconds(2);
        m_Audio.Play();
        yield return new WaitForSeconds(5);
        // Fade out Materials
        fadeOutMaterials();
        // Fade out Controllers
        if (modelControllers.isActive) {
            modelControllers.fadePanelOut();
        }
        // Hide Menu Items
        modelMenu.fadePanelOut();
        // Fade out podium
        podium.FadeOut();
        warpIn.Stop();
        yield return new WaitForSeconds(3);
        m_Audio.Stop();
        yield return new WaitForSeconds(1);
        // Fade in Main UI Panel
        mainUIPanel.fadeInPanels();
        playPause = !playPause;
    }

    public void setModel(int model) {
        activeModel = Models[model];
        fadeMaterial = activeModel.GetComponentsInChildren<FadeMaterial>();
        playPauseRotate();
        entranceAnimation();
    }

    public void rotateLeft() {
        activeModel.transform.Rotate(Vector3.up * rotateDistance);
    }

    public void rotateRight()
    {
        activeModel.transform.Rotate(Vector3.up * -rotateDistance);  
    }

    public void playPauseRotate() {
        playPause = !playPause;
    }

    IEnumerator RotateModel(float rotDistance) {
        activeModel.transform.Rotate(Vector3.up * -rotDistance);
        yield return null;
    }

    // Update is called once per frame
    void Update () {
        if (playPause) {
            activeModel.transform.Rotate(Vector3.up * Time.deltaTime * rotatationSpeed);
        }
    }
}
