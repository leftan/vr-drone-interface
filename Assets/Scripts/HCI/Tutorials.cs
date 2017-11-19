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
        public GameObject StepThreeText;
        public GameObject firstPointer;
        private int tutorialTimer;
        private int frameCounter;
        private GameObject drone;
        private GameObject controller;
        private bool placingDrone;
        private bool stepOneFinished;
        private bool stepTwoFinished;

        // Use this for initialization
        void Start()
        {
            welcomeText.SetActive(true);
            stepOneText.SetActive(false);
            stepTwoText.SetActive(false);
            StepThreeText.SetActive(false);

            firstPointer.SetActive(false);
            drone = GameObject.FindGameObjectWithTag("Drone");
            controller = GameObject.FindGameObjectWithTag("GameController");
            placingDrone = false;
            stepOneFinished = false;
            stepTwoFinished = false;
            
      

        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(tutorialTimer);
            frameCounter++;
            if (tutorialTimer + 300 < frameCounter)
            {
                welcomeText.SetActive(false);
                placingDrone = controller.GetComponent<VRTK_StraightPointerRenderer>().setDrone;
                if (!stepOneFinished)
                {
                    stepOneText.SetActive(true);
                }
                if (placingDrone && !stepOneFinished && !stepTwoFinished)
                {
                    stepOneFinished = true;
                    stepOneText.SetActive(false);
                    stepTwoText.SetActive(true);
                    firstPointer.SetActive(true);
                    
                }

               
                if (placingDrone && !stepTwoFinished && controller.GetComponent<VRTK_StraightPointerRenderer>().OnGround() 
                    && OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) != 0)
                {
                    stepTwoFinished = true;
                    stepTwoText.SetActive(false);
                    StepThreeText.SetActive(true);
                }
            }


        }


    }
}
