using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    public FloorCeiling floorCeiling;
    // Need to add transition for windows

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void fadeInFloorCeiling() {
        floorCeiling.fadeFloorCeilingIn();
    }
}
