using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{

    public class LecternTrigger : MonoBehaviour
    {
        [SerializeField] private Material material;
        [SerializeField] private GameObject leverPanelPrefab;
        private GameObject leverPanel;
        private bool inTriggerArea = false;
        private bool isGateOpen = false;

        private void Start()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("in lectern trigger area");
                inTriggerArea = true;

                if (leverPanel == null)
                {
                    leverPanel = Instantiate(leverPanelPrefab, GameObject.FindObjectOfType<Canvas>().transform);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            inTriggerArea = false;
            Destroy(leverPanel);
        }

        private void Update()
        {
            // changes lectern to green if player is inside trigger area, and presses e
            if (Input.GetKeyDown(KeyCode.E) && inTriggerArea)
            {
                Debug.Log("pressed e");
                if (!isGateOpen)
                {
                    material.color = Color.green;
                    GameObject.Find("Gate").GetComponent<GateController>().OpenGate();
                    isGateOpen = true;
                }
                else
                {
                    material.color = Color.red;
                    GameObject.Find("Gate").GetComponent<GateController>().CloseGate();
                    isGateOpen = false;
                }
                
            }
        }

        private void OnDestroy()
        {
            material.color = Color.red;
        }
    }
}