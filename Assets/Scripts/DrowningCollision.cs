using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{
    public class DrowningCollision : MonoBehaviour
    {
        [SerializeField] private GameObject drownPanel;
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("You have drowned.");

            Instantiate(drownPanel, FindObjectOfType<Canvas>().transform);
        }
    }
}
