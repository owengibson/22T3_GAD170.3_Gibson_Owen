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

        public delegate void BridgeEvent();
        public event BridgeEvent LeverDown;
        public event BridgeEvent LeverUp;

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
                        if (LeverDown != null) LeverDown();
                    }
                    else
                    {
                        if (LeverUp != null) LeverUp();
                    }
                }
            }
            else
            {
                if (leverPanel != null) Destroy(leverPanel);
            }
        }

        public void Subscribe()
        {
            
        }

        public void Unsubscribe()
        {
            throw new System.NotImplementedException();
        }
    }
}