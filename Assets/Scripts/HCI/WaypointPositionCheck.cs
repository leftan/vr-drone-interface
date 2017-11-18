namespace VRTK
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class WaypointPositionCheck : MonoBehaviour {

        private GameObject[] waypoints; // Waypoint object    

        public GameObject bluePointer;
        
        void Start()
        {
            waypoints = GameObject.FindGameObjectsWithTag("waypoint");
            Debug.Log("amount of waypoint " + waypoints.Length);
        }

        void Update()
        {
            
        }

        //public void DestroyPointer()
        //{
        //    GameObject pointer = GameObject.FindGameObjectWithTag("Pointer");
        //    if (pointer != null)
        //    {
        //        Destroy(menu);
        //    }

        //    foreach (GameObject i in waypoints)
        //    {
        //        Destroy(i);
        //    }
        //}


    }
}
