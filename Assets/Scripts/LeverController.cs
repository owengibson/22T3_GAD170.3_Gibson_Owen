using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{
    public class LeverController : MonoBehaviour
    {
        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void LeverDown()
        {
            anim.Play("Lever Down");
        }

        public void LeverUp()
        {
            anim.Play("Lever Up");
        }
    }
}