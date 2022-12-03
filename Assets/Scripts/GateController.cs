using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{
    public class GateController : MonoBehaviour
    {
        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        private void OpenGate()
        {
            anim.Play("Gate Open");
        }

        private void CloseGate()
        {
            anim.Play("Gate Close");
        }

        private void OnEnable()
        {
            FindObjectOfType<GateToggleLectern>().LeverDown += OpenGate;
            FindObjectOfType<GateToggleLectern>().LeverUp += CloseGate;

        }

        private void OnDisable()
        {
            FindObjectOfType<GateToggleLectern>().LeverDown -= OpenGate;
            FindObjectOfType<GateToggleLectern>().LeverUp -= CloseGate;
        }
    }

    
}