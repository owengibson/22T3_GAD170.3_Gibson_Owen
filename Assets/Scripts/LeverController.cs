using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{
    public class LeverController : MonoBehaviour
    {
        private Animator anim;
        private GameObject parentLectern;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        private void MoveLeverDown()
        {
            anim.Play("Lever Down");
        }

        private void MoveLeverUp()
        {
            anim.Play("Lever Up");
        }

        private void OnEnable()
        {
            parentLectern = gameObject.transform.parent.transform.parent.gameObject;
            if (parentLectern.name == "Tangible Toggle Lectern")
            {
                EventsManager.TangibilityLeverDown += MoveLeverDown;
                EventsManager.TangibilityLeverUp += MoveLeverUp;
            }
            else if (parentLectern.name == "Gate Toggle Lectern")
            {
                EventsManager.GateLeverDown += MoveLeverDown;
                EventsManager.GateLeverUp += MoveLeverUp;
            }
        }

        private void OnDisable()
        {
            if (parentLectern.name == "Tangible Toggle Lectern")
            {
                EventsManager.TangibilityLeverDown -= MoveLeverDown;
                EventsManager.TangibilityLeverUp -= MoveLeverUp;
            }
            else if (parentLectern.name == "Gate Toggle Lectern")
            {
                EventsManager.GateLeverDown -= MoveLeverDown;
                EventsManager.GateLeverUp -= MoveLeverUp;
            }
        }
    }
}