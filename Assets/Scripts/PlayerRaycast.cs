using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{
    public class PlayerRaycast : MonoBehaviour
    {
        [Range(1f, 10f)]
        [SerializeField] float rayLength = 4.0f;
        public string lookingAt;

        private void FixedUpdate()
        {
            Ray ray = new Ray(transform.position, transform.forward);

            Debug.DrawRay(transform.position, transform.forward * rayLength);

            if (Physics.Raycast(ray, out RaycastHit hit, rayLength))
            {
                lookingAt = hit.collider.gameObject.name;
            }
            else
            {
                lookingAt = "";
            }
        }
    }
}