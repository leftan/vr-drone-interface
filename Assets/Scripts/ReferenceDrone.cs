namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ReferenceDrone : MonoBehaviour
    {
        public GameObject referenceDrone;
        public GameObject movementButton;
        public GameObject destroyDroneButton;
        //public GameObject droneMenu;
        
        void Start()
        {
            movementButton.GetComponent<ToggleDroneMovement>().referenceDrone = referenceDrone;
            destroyDroneButton.GetComponent<DestroyDrone>().referenceDrone = referenceDrone;
            //droneMenu = GameObject.FindGameObjectWithTag("DroneMenu");

        }

        void Update()
        {
            Debug.Log(referenceDrone);
            //Debug.Log(droneMenu);
            if (referenceDrone == null)
            {
                //droneMenu.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}