using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{
    public class DrowningCollision : MonoBehaviour
    {
        [SerializeField] private GameObject drownPanel;
        private GameObject player;
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("You have drowned.");

            Instantiate(drownPanel, FindObjectOfType<Canvas>().transform);
            player.GetComponent<PlayerMovement>().DisableMovement();
        }

        private void Start()
        {
            player = GameObject.Find("Player");
        }
    }
}
