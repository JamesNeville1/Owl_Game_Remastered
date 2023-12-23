using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SCR_utils {
    public class custom_attributes{
        public class ReadOnlyAttribute : PropertyAttribute { }
    }
    public class functions {
        static public void attack(float damage = 0, SCR_health target = null) {
            if (target != null && target.check()) target.adjust(-damage);   
        }
    }
}
