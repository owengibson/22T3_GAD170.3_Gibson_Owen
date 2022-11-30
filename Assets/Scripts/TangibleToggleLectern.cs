using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace OwenGibson
{

    public class TangibleToggleLectern : MonoBehaviour
    {
        [SerializeField] private GameObject leverPanelPrefab;

        private BridgeController bridgeController;
        private LeverController leverController;
        private GameObject leverPanel;
        private PlayerRaycast playerRaycast;
        private Canvas canvas;

        void Start()
        {
            bridgeController = GameObject.Find("Bridge").GetComponent<BridgeController>();
            leverController = GetComponentInChildren<LeverController>();
            playerRaycast = GameObject.Find("Player/Camera").GetComponent<PlayerRaycast>();
            canvas = FindObjectOfType<Canvas>();
        }


        void Update()
        {
            if(playerRaycast.lookingAt == "Tangible Toggle Lectern")
            {
                if (leverPanel == null) leverPanel = Instantiate(leverPanelPrefab, canvas.transform);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!bridgeController.isTangible)
                    {
                        bridgeController.TurnTangible();
                        leverController.LeverDown();
                    }
                    else
                    {
                        bridgeController.TurnIntangible();
                        leverController.LeverUp();
                    }
                }
            }
            else
            {
                if (leverPanel != null) Destroy(leverPanel);
            }
        }
    }
}