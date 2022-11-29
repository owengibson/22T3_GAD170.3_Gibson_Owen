using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{
    public class LeverController : MonoBehaviour
    {
        private Animator anim;
        // Start is called before the first frame update
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