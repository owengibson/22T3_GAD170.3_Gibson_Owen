using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{
    public class LecternInteract : MonoBehaviour
    {
        [SerializeField] private GameObject leverPanelPrefab;

        private GameObject leverPanel;
        private GateController gateController;
        private LeverController leverController;
        private PlayerRaycast playerRaycast;
        private bool isGateOpen = false;

        private void Start()
        {
            gateController = GameObject.Find("Gate").GetComponent<GateController>();
            leverController = GameObject.Find("Lever/Handle").GetComponent<LeverController>();
            playerRaycast = GameObject.Find("Player/Camera").GetComponent<PlayerRaycast>();
        }

        private void Update()
        {
            if (playerRaycast.lookingAtLectern) // currently flashes UI panel on screen
            {
                if (leverPanel == null) leverPanel = Instantiate(leverPanelPrefab, FindObjectOfType<Canvas>().transform);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("pressed e");
                    if (!isGateOpen)
                    {
                        leverController.LeverDown();
                        gateController.OpenGate();
                        isGateOpen = true;
                    }
                    else
                    {
                        leverController.LeverUp();
                        gateController.CloseGate();
                        isGateOpen = false;
                    }

                }
            }
            else
            {
                if(leverPanel != null) Destroy(leverPanel);
            }
        }
    }
}