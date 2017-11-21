namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class WaypointMoved : MonoBehaviour
    {
        public bool isWaypointAdded;
        private int preCount;
        private int curCount;
        // Use this for initialization
        void Start()
        {
            isWaypointAdded = false;
        }

        // Update is called once per frame
        void Update()
        {
         

        }

        IEnumerator countWaypoints()
        {
            preCount = GameObject.FindGameObjectsWithTag("waypoint").Length;
            Debug.Log("preCount " + preCount);
            yield return new WaitForSeconds(5);
            curCount = GameObject.FindGameObjectsWithTag("waypoint").Length;
            Debug.Log("curCount " + curCount);
            if (curCount - preCount != 0)
            {
                isWaypointAdded = true;
            } else
            {
                isWaypointAdded = false;
            }
        }
    }
}
