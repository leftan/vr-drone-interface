namespace VRTK
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PositionCheck : MonoBehaviour
    {
        private GameObject[] waypoints;
        private GameObject[] pointers;
        private GameObject bluePointer;
        private GameObject drone;
        private Vector3 pointerPosition;
        private Vector3 waypointPosition;
        private Vector3 dronePosition;
        private Vector3 bluePointerPosition;
        private float absDroneX;
        private float absDroneZ;
        private float absDroneDistance;
        private float absWaypointDistance;
        private float absWaypointX;
        private float absWaypointZ;


        void Start()
        {
            
           
        }

        void Update()
        {

            //pointers = GameObject.FindGameObjectsWithTag("Pointer");
            bluePointer = GameObject.FindGameObjectWithTag("BluePointer");
            bluePointerPosition = bluePointer.transform.position;
            waypoints = GameObject.FindGameObjectsWithTag("waypoint");
            drone = GameObject.FindGameObjectWithTag("Drone");
            if (drone != null)
            {
                dronePosition = drone.transform.position;
            }
            
            //Debug.Log("drone position: " + dronePosition);
            absDroneX = Mathf.Abs(dronePosition.x - bluePointerPosition.x);
            absDroneZ = Mathf.Abs(dronePosition.z - bluePointerPosition.z);
            absDroneDistance = Mathf.Sqrt(absDroneX * absDroneX + absDroneZ * absDroneZ);

            // Debug.Log("Drone Position X: " + dronePosition.x + "Pointer Position X: " + pointerPosition.x + "Drone Position Z: " + dronePosition.z + "Pointer Position Z: " + pointerPosition.z +  "absDroneX " + absDroneX + "absDroneZ " + absDroneZ);
            //Debug.Log("absDroneDistance: " + absDroneDistance);
            if (absDroneDistance < 0.3)
            {
               
                Destroy(bluePointer);
            }

            //foreach (GameObject pointer in pointers) 
            //{
            //    pointerPosition = pointer.transform.position;  
                
                
            //    foreach (GameObject waypoint in waypoints)
            //    {
            //        waypointPosition = waypoint.transform.position;
            //        absWaypointX = Mathf.Abs(waypointPosition.x - pointerPosition.x);
            //        absWaypointZ = Mathf.Abs(waypointPosition.z - pointerPosition.z);
            //        absWaypointDistance = Mathf.Sqrt(absWaypointX * absWaypointX + absWaypointZ * absWaypointZ);
            //        Debug.Log("absWaypointDistance: " + absWaypointDistance);
            //        if (absWaypointDistance < 0.3)
            //        {

            //            if (pointer != null)
            //            {
            //                Destroy(pointer);
            //            }
            //        }
            //    }

            //}
            
        }

    }
}
