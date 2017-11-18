namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SpawnDrone : MonoBehaviour
    {

        public GameObject drone;
        public GameObject mainMenu;

        private GameObject world;
        private GameObject controller;
        //menuState stores if the main menu is currently active
        private bool menuState;
        //toggleMenuStopper
        private bool toggleMenuStopper;
        private bool placingDrone;
        private Vector3 groundPoint;

        // Use this for initialization
        void Start()
        {
            world = GameObject.FindGameObjectWithTag("World");
            controller = GameObject.FindGameObjectWithTag("GameController");
            menuState = false;
            toggleMenuStopper = true;
            mainMenu.SetActive(menuState);
        }

        // Update is called once per frame
        void Update()
        {

            if (OVRInput.Get(OVRInput.Button.One))
            {
                if (toggleMenuStopper)
                {
                    mainMenu.SetActive(!menuState);
                    menuState = !menuState;
                    toggleMenuStopper = false;
                }
            }
            else
            {
                toggleMenuStopper = true;
            }

<<<<<<< HEAD
            //Debug.Log(OVRInput.Get(OVRInput.Button.SecondaryHandTrigger));
=======
            Debug.Log(OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger));
        
>>>>>>> bc3ea4eab3812c29b4b1ee21232196ac724e5a66
            if (placingDrone && controller.GetComponent<VRTK_StraightPointerRenderer>().OnGround() && OVRInput.Get(OVRInput.Button.Two))
            {
                Debug.Log("it si not working!!!");
                ChooseGroundPoint();
                controller.GetComponent<VRTK_StraightPointerRenderer>().placingDrone();
            }
        }

        public void OnClick()
        {
            controller.GetComponent<VRTK_StraightPointerRenderer>().placingDrone();
            placingDrone = true;
           // Debug.Log("OnClick is working");
            mainMenu.SetActive(false);
            menuState = !menuState;
            GameObject[] drones = GameObject.FindGameObjectsWithTag("Drone");
            foreach (GameObject i in drones)
            {
                i.GetComponent<SetWaypoint>().selected = false;
                i.GetComponent<DroneMenuActivator>().selected = false;
            }
        }

        private void ChooseGroundPoint()
        {
            Vector3 groundPoint = controller.GetComponent<VRTK_StraightPointerRenderer>().GetGroundPoint();
            groundPoint.y = groundPoint.y + 0.5f * world.GetComponent<ControllerInteractions>().actualScale.y;
            Instantiate(drone, groundPoint, Quaternion.identity, world.transform);
            placingDrone = false;
            //Debug.Log(pointerCollidedWith.point.y + " point");
        }

        // Returns the height taking the scale into account
        private float MaxHeight()
        {
            return 1 + (float)((1.0008874438 * 1.5 - 0.7616114718) * world.GetComponent<ControllerInteractions>().actualScale.y + .703);
        }
    }
}