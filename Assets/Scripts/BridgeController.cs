using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{
    public class BridgeController : MonoBehaviour
    {
        [SerializeField] private Material tangibleMaterial;
        [SerializeField] private Material intangibleMaterial;

        private BoxCollider[] boxColliders;
        private MeshCollider meshCollider;
        private GameObject bridge;
        private GameObject gate;


        private void Start()
        {
            bridge = GameObject.Find("Bridge/Bridge Model");
            gate = GameObject.Find("Bridge/Gate");
            boxColliders = GetComponentsInChildren<BoxCollider>();
            meshCollider = GetComponentInChildren<MeshCollider>();
        }

        private void TurnTangible()
        {
            foreach(BoxCollider collider in boxColliders)
            {
                collider.enabled = true;
            }

            meshCollider.enabled = true;

            bridge.GetComponent<MeshRenderer>().material = tangibleMaterial;
            gate.GetComponent<MeshRenderer>().material = tangibleMaterial;
        }

        private void TurnIntangible()
        {
            foreach(BoxCollider collider in boxColliders)
            {
                collider.enabled = false;

                meshCollider.enabled = false;

                bridge.GetComponent<MeshRenderer>().material = intangibleMaterial;
                gate.GetComponent<MeshRenderer>().material = intangibleMaterial;
            }
        }

        private void OnEnable()
        {
            EventsManager.TangibilityLeverDown += TurnTangible;
            EventsManager.TangibilityLeverUp += TurnIntangible;

        }

        private void OnDisable()
        {
            EventsManager.TangibilityLeverDown -= TurnTangible;
            EventsManager.TangibilityLeverUp -= TurnIntangible;
        }
    }
}