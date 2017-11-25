namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Tutorials : MonoBehaviour
    {
        //private GameObject welcomeText;
        //private GameObject stepOneText;
        //private GameObject stepTwoText;
        //private GameObject stepThreeText;
        //private GameObject stepFourText;
        //private GameObject stepFiveText;
        //private GameObject stepSixText;
        //private GameObject stepSevenText;

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

        private static int prevStep = 0;
        private List<GameObject> stepTexts = new List<GameObject>();

        // Use this for initialization
        void Start()
        {
            //welcomeText = gameObject.transform.GetChild(0).gameObject;
            //stepOneText = gameObject.transform.GetChild(1).gameObject;
            //stepTwoText = gameObject.transform.GetChild(2).gameObject;
            //stepThreeText = gameObject.transform.GetChild(3).gameObject;
            //stepFourText = gameObject.transform.GetChild(4).gameObject;
            //stepFiveText = gameObject.transform.GetChild(5).gameObject;
            //stepSixText = gameObject.transform.GetChild(6).gameObject;
            //stepSevenText = gameObject.transform.GetChild(7).gameObject;

            stepTexts.Add(welcomeText);
            stepTexts.Add(stepOneText);
            stepTexts.Add(stepTwoText);
            stepTexts.Add(stepThreeText);
            stepTexts.Add(stepFourText);
            stepTexts.Add(stepFiveText);
            stepTexts.Add(stepSixText);
            stepTexts.Add(stepSevenText);

            stepTexts[0].SetActive(true);
            prevStep = 0;

            stepTexts[1].SetActive(false);
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
                stepTexts[0].SetActive(false);
                placingDrone = controller.GetComponent<VRTK_StraightPointerRenderer>().setDrone;
                droneMenu = GameObject.FindGameObjectWithTag("DroneMenu");

                if (!stepOneFinished)
                {
                    stepTexts[1].SetActive(true);
                    prevStep = 1;

                    //Debug.Log("step 1 is on");
                    stepOneFinished = true;

                }
                else if (placingDrone) 
                {
                    //Debug.Log("OnGround() " + controller.GetComponent<VRTK_StraightPointerRenderer>().OnGround());
                    
                    //Debug.Log("IndexTrigger " + indexTriggerOn);
                    //if (!stepTwoFinished)
                    //{
                        //Debug.Log("step 2 is on");
                        stepTexts[prevStep].SetActive(false);
                        stepTexts[2].SetActive(true);
                        prevStep = 2;

                        firstPointer.SetActive(true);
                        stepTwoFinished = true;
                    //}

                }

                if (GameObject.FindGameObjectsWithTag("waypoint").Length != 0 && !stepFourFinished)
                    //&& referenceDrone.GetComponent<SetWaypoint>().selected)
                {
                    stepTexts[prevStep].SetActive(false);
                    stepTexts[4].SetActive(true);
                    prevStep = 4;

                    secondPointer.SetActive(false);
                    
                    stepFourFinished = true;
                    Debug.Log("adjust height " + GameObject.FindGameObjectWithTag("Drone").GetComponentInChildren<SetWaypoint>().adjustingHeight);
                    

                }

                if (!GameObject.FindGameObjectWithTag("Drone").GetComponentInChildren<SetWaypoint>().adjustingHeight 
                    && !stepFiveFinished && stepFourFinished && !stepSevenFinished && !stepSixFinished)
                {
                    stepTexts[prevStep].SetActive(false);
                    thirdPointer.SetActive(true);
                    stepTexts[5].SetActive(true);
                    prevStep = 5;

                    stepFiveFinished = true;
                }

                waypointMoveTime = GameObject.FindGameObjectsWithTag("waypoint").Length - GameObject.FindGameObjectsWithTag("Groundpoint").Length;
            
                if (stepFiveFinished && !stepSixFinished && waypointMoveTime < 1 && !stepSevenFinished)
                {
                    stepTexts[prevStep].SetActive(false);
                    stepTexts[6].SetActive(true);
                    prevStep = 6;

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
                    stepTexts[prevStep].SetActive(false);
                    stepTexts[7].SetActive(true);
                    prevStep = 7;

                    //stepSevenFinished = true;
                    //fourthPointer.SetActive(false);

                }

            }
            

        }

        public void OnInstantiateDrone()
        {
            Debug.Log("On instantiate drone");
            stepTexts[prevStep].SetActive(false);
            stepTexts[3].SetActive(true);
            prevStep = 3;
 
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
