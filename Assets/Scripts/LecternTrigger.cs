using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{

    public class LecternTrigger : MonoBehaviour
    {
        [SerializeField] private Material material;
        private bool inTriggerArea = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("in lectern trigger area");
                inTriggerArea = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            inTriggerArea = false;
        }

        private void Update()
        {
            // changes lectern to green if player is inside trigger area, and presses e
            if (Input.GetKeyDown(KeyCode.E) && inTriggerArea)
            {
                Debug.Log("pressed e");
                if (material.color == Color.red)
                {
                    material.color = Color.green;
                }
                else
                {
                    material.color = Color.red;
                }
            }
        }

        private void OnDestroy()
        {
            material.color = Color.red;
        }
    }
}