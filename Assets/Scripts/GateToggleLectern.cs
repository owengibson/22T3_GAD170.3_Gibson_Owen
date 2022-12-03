using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{
    public class GateToggleLectern : MonoBehaviour
    {
        [SerializeField] private GameObject leverPanelPrefab;

        private GameObject leverPanel;
        private GateController gateController;
        private LeverController leverController;
        private PlayerRaycast playerRaycast;
        private Canvas canvas;
        private bool isGateOpen = false;

        public delegate void GateEvent();
        public event GateEvent LeverDown;
        public event GateEvent LeverUp;

        private void Start()
        {
            gateController = GameObject.Find("Gate").GetComponent<GateController>();
            leverController = GetComponentInChildren<LeverController>();
            playerRaycast = GameObject.Find("Player/Camera").GetComponent<PlayerRaycast>();
            canvas = FindObjectOfType<Canvas>();

        }

        private void Update()
        {
            if (playerRaycast.lookingAt == "Gate Toggle Lectern")
            {
                if (leverPanel == null) leverPanel = Instantiate(leverPanelPrefab, canvas.transform);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("pressed e");
                    if (!isGateOpen)
                    {
                        LeverDown();
                        isGateOpen = true;
                    }
                    else
                    {
                        LeverUp();
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