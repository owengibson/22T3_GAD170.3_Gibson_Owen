using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{
    public class BridgeController : MonoBehaviour
    {
        [SerializeField] private Material tangibleMaterial;
        [SerializeField] private Material intangibleMaterial;

        public bool isTangible;

        private BoxCollider[] boxColliders;
        private GameObject bridge;
        private GameObject gate;


        private void Start()
        {
            bridge = GameObject.Find("Bridge/Bridge Model");
            gate = GameObject.Find("Bridge/Gate");
            boxColliders = GetComponentsInChildren<BoxCollider>();
        }

        private void TurnTangible()
        {
            foreach(BoxCollider collider in boxColliders)
            {
                collider.enabled = true;
            }

            GetComponentInChildren<MeshCollider>().enabled = true;

            bridge.GetComponent<MeshRenderer>().material = tangibleMaterial;
            gate.GetComponent<MeshRenderer>().material = tangibleMaterial;

            isTangible = true;
        }

        private void TurnIntangible()
        {
            foreach(BoxCollider collider in boxColliders)
            {
                collider.enabled = false;

                GetComponentInChildren<MeshCollider>().enabled = false;

                bridge.GetComponent<MeshRenderer>().material = intangibleMaterial;
                gate.GetComponent<MeshRenderer>().material = intangibleMaterial;

                isTangible = false;
            }
        }

        private void OnEnable()
        {
            FindObjectOfType<TangibleToggleLectern>().LeverDown += TurnTangible;
            FindObjectOfType<TangibleToggleLectern>().LeverUp += TurnIntangible;

        }

        private void OnDisable()
        {
            FindObjectOfType<TangibleToggleLectern>().LeverDown -= TurnTangible;
            FindObjectOfType<TangibleToggleLectern>().LeverUp -= TurnIntangible;
        }
    }
}