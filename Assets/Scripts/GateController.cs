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

        public void OpenGate()
        {
            anim.Play("Gate Open");
        }

        public void CloseGate()
        {
            anim.Play("Gate Close");
        }
    }
}