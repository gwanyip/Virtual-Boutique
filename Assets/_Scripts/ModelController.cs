using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class ModelController : MonoBehaviour {

    public bool turnRight;
    public bool turnLeft;

    public ModelContainer modelContainer;
    [SerializeField]
    private VRInteractiveItem m_InteractiveItem;                        // The interactive item for where the user should click to load the level.
    [SerializeField]
    private AudioSource m_Audio;                                        // Reference to the audio source that will play effects when the user looks at it and when it fills.
    [SerializeField]
    private AudioClip m_OnClick;                                     // The clip to play when the user looks at the bar.

    private void OnEnable()
    {
        m_InteractiveItem.OnClick += HandleClick;
    }


    private void OnDisable()
    {
        m_InteractiveItem.OnClick -= HandleClick;
    }

    //Handle the Click event
    private void HandleClick()
    {
        if (turnRight)
        {
            // Play the clip appropriate for when the user starts looking at the bar.
            m_Audio.clip = m_OnClick;
            m_Audio.Play();

            modelContainer.rotateRight();
        }
        else if (turnLeft)
        {
            // Play the clip appropriate for when the user starts looking at the bar.
            m_Audio.clip = m_OnClick;
            m_Audio.Play();
            modelContainer.rotateLeft();
        }
    }
}
