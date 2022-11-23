using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] private GameObject panelPrefab;
    private GameObject panel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Tutorial popup");

            if (panel == null)
            {
                panel = Instantiate(panelPrefab, GameObject.FindObjectOfType<Canvas>().transform);
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
