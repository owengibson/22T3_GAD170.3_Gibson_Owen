using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{
    public class PlayerRaycast : MonoBehaviour
    {
        [Range(1f, 10f)]
        [SerializeField] float rayLength = 4.0f;
        public bool lookingAtLectern = false;
        private void FixedUpdate()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            Debug.DrawRay(transform.position, transform.forward * rayLength);

            if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.name == "Lectern")
            {
                lookingAtLectern = true;
            }
            else
            {
                lookingAtLectern = false;
            }
        }
    }
}