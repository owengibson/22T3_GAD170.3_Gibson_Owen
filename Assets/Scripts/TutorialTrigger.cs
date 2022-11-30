using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{

    public class TutorialTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject panelPrefab;
        private GameObject panel;
        private Canvas canvas;

        private void Start()
        {
            canvas = FindObjectOfType<Canvas>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Tutorial popup");

                if (panel == null)
                {
                    panel = Instantiate(panelPrefab, canvas.transform);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Destroy tutorial");
                Destroy(panel);
            }
        }
    }
}