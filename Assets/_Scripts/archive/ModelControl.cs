using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Examples
{
    public class ModelControl : MonoBehaviour {

        public bool turnRight;
        public bool turnLeft;
        public bool playPause;
        public ModelContainer modelContainer;
        [SerializeField]
        private SelectionRadial m_SelectionRadial;                          // This controls when the selection is complete.
        [SerializeField]
        private VRInteractiveItem m_InteractiveItem;                        // The interactive item for where the user should click to load the level.

        private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.


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
        }


        private void HandleOut()
        {
            // When the user looks away from the rendering of the scene, hide the radial.
            m_SelectionRadial.Hide();

            m_GazeOver = false;
        }

        // Start of existing code

        //Handle the Click event
        private void HandleClick()
        {
            Debug.Log("Show click state");
            if (turnRight)
            {
                modelContainer.rotateRight();
            }
            else if (turnLeft)
            {
                modelContainer.rotateLeft();
            }
            else if (playPause) {
                modelContainer.playPauseRotate();
            }
        }

    }
}


