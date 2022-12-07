using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{
    public class EventsManager
    {
        public delegate void VoidDelegate();
        public static VoidDelegate TangibilityLeverDown;
        public static VoidDelegate TangibilityLeverUp;
        public static VoidDelegate GateLeverDown;
        public static VoidDelegate GateLeverUp;
    }
}