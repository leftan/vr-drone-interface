using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapbox_mapcontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        AddChildTag();
		
	}

    public void AddChildTag ()
    {
        foreach(Transform t in transform)
        {
            t.gameObject.tag = "Ground";
        }
    }
}
