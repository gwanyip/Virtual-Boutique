using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class MainUIPanelItemCTA : MonoBehaviour {

    public bool Dress1 = false;
    public bool Dress2 = false;

    [SerializeField] private ModelContainer modelContainer;             // Model Container

    [SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
    [SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.
    [SerializeField] private MainUIPanel mainUIPanelItem;               // Parent UI Panel

    private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Script to handle Radial Recticle hover
        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;
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

    // Logic to handle click action
    private void HandleSelectionComplete()
    {
        Debug.Log("UI Panel Item CTA selection");
        mainUIPanelItem.fadeOutPanels();
        // Trigger entrace Animation for selected model
        if (Dress1)
        {
            Debug.Log("Dress1");
            modelContainer.setModel(0);
        }
        if (Dress2) {
            Debug.Log("Dress2");
            modelContainer.setModel(1);
        }     
    }
}
