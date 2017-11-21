namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Tutorials : MonoBehaviour
    {

        public GameObject welcomeText;
        public GameObject stepOneText;
        public GameObject stepTwoText;
        public GameObject stepThreeText;
        public GameObject stepFourText;
        public GameObject stepFiveText;
        public GameObject stepSixText;
        public GameObject stepSevenText;

        public GameObject firstPointer;
        public GameObject secondPointer;
        public GameObject thirdPointer;
        public GameObject fourthPointer;

        public GameObject world;
        private int tutorialTimer;
        private int frameCounter;
        private GameObject drone;
        private GameObject droneMenu;
        private GameObject controller;
        private bool placingDrone;
        private bool stepOneFinished;
        private bool stepTwoFinished;
        private bool indexTriggerOn;
        private bool stepFourFinished;
        private bool stepFiveFinished;
        private bool stepSixFinished;
        private bool stepSevenFinished;

        private int waypointMoveTime;
        private int curWaypointNumber;
        private int lasWaypointNumber;


        // Use this for initialization
        void Start()
        {
            welcomeText.SetActive(true);
            stepOneText.SetActive(false);
            stepTwoText.SetActive(false);
            stepThreeText.SetActive(false);
            stepFourText.SetActive(false);
            stepFiveText.SetActive(false);
            stepSixText.SetActive(false);
            stepSevenText.SetActive(false);

            firstPointer.SetActive(false);
            secondPointer.SetActive(false);
            thirdPointer.SetActive(false);
            fourthPointer.SetActive(false);
            
            controller = GameObject.FindGameObjectWithTag("GameController");
            placingDrone = false;
            stepOneFinished = false;
            stepTwoFinished = false;
            stepFourFinished = false;
            stepSixFinished = false;
            stepSevenFinished = false;
            indexTriggerOn = false;

            lasWaypointNumber = GameObject.FindGameObjectsWithTag("waypoint").Length;





        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(tutorialTimer);
            //Debug.Log(OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger));
           
            //Debug.Log(OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch);

            frameCounter++;
            
            if (tutorialTimer + 300 < frameCounter)
            {
                welcomeText.SetActive(false);
                placingDrone = controller.GetComponent<VRTK_StraightPointerRenderer>().setDrone;
                droneMenu = GameObject.FindGameObjectWithTag("DroneMenu");

                if (!stepOneFinished)
                {
                    stepOneText.SetActive(true);
                    //Debug.Log("step 1 is on");
                    stepOneFinished = true;
                }
                else if (placingDrone) 
                {
                    //Debug.Log("OnGround() " + controller.GetComponent<VRTK_StraightPointerRenderer>().OnGround());
                    
                    //Debug.Log("IndexTrigger " + indexTriggerOn);
                    if (!stepTwoFinished)
                    {
                        //Debug.Log("step 2 is on");
                        stepOneText.SetActive(false);
                        stepTwoText.SetActive(true);
                        firstPointer.SetActive(true);
                        stepTwoFinished = true;
                    }

                }

                if (GameObject.FindGameObjectsWithTag("waypoint").Length != 0 && !stepFourFinished)
                    //&& referenceDrone.GetComponent<SetWaypoint>().selected)
                {   
                    stepThreeText.SetActive(false);
                    stepFourText.SetActive(true);
                    secondPointer.SetActive(false);
                    
                    stepFourFinished = true;
                    Debug.Log("adjust height " + GameObject.FindGameObjectWithTag("Drone").GetComponentInChildren<SetWaypoint>().adjustingHeight);
                    

                }

                if (!GameObject.FindGameObjectWithTag("Drone").GetComponentInChildren<SetWaypoint>().adjustingHeight 
                    && !stepFiveFinished && stepFourFinished && !stepSevenFinished && !stepSixFinished)
                {
                    stepFourText.SetActive(false);
                    thirdPointer.SetActive(true);
                    stepFiveText.SetActive(true);
                    stepFiveFinished = true;
                }

                waypointMoveTime = GameObject.FindGameObjectsWithTag("waypoint").Length - GameObject.FindGameObjectsWithTag("Groundpoint").Length;
            
                if (stepFiveFinished && !stepSixFinished && waypointMoveTime < 1 && !stepSevenFinished)
                {
                    stepFiveText.SetActive(false);
                    stepSixText.SetActive(true);
                    stepSixFinished = true;
                    fourthPointer.SetActive(true);
                    //lasWaypointNumber = curWaypointNumber;
                    Debug.Log("is waypoint added " + world.GetComponent<WaypointMoved>().isWaypointAdded);

                }
                //Debug.Log("step 7 " + stepSevenFinished);
                if (stepSixFinished && !stepSevenFinished && 
                    !GameObject.FindGameObjectWithTag("Drone").GetComponentInChildren<SetWaypoint>().settingInterWaypoint &&
                    GameObject.FindGameObjectsWithTag("waypoint").Length > 2)
                {
                    stepSixText.SetActive(false);
                    stepSevenText.SetActive(true);
                    //stepSevenFinished = true;
                    //fourthPointer.SetActive(false);
                   
                }

            }
            

        }

        public void OnInstantiateDrone()
        {
            stepTwoText.SetActive(false);
            stepThreeText.SetActive(true);
            firstPointer.SetActive(false);
            secondPointer.SetActive(true);
        }

        void IndexTriggerCheck()
        {
            if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0.4)
            {
                indexTriggerOn = true;
                Debug.Log("index trigger check" + indexTriggerOn);
            }
            else
            {
                indexTriggerOn = false;
            }
        }


    }
}
