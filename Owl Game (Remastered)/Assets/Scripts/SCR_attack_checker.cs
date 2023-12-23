using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SCR_attack_checker {
    public class radialChecker {
        public static radialChecker create(float radius, string targetTag, GameObject parent = null)
        {
            radialChecker newChecker = new radialChecker(targetTag);
            GameObject obj = new GameObject("My Radial Attack Checker", typeof(hook));

            if (parent != null) obj.transform.parent = parent.transform;
            obj.transform.localPosition = Vector3.zero;

            obj.AddComponent<CircleCollider2D>().radius = radius;
        
            hook hook = obj.GetComponent<hook>();
            hook.onTrig = newChecker.onTrig;

            return newChecker;
        }

        public class hook : MonoBehaviour{
            public Action<Collider2D> onTrig;
            private void OnTriggerEnter2D(Collider2D collision) {
                onTrig(collision);
            }
        }

        string targetTag;
        SCR_health target;

        public radialChecker(string targetTag) {
            this.targetTag = targetTag;
        }

        void onTrig(Collider2D col) {
            if(col.tag == targetTag) {
                col.TryGetComponent<SCR_health>(out target);
            }
        }

        public SCR_health returnTarget() {
            return target;
        }
    }
    public class rayChecker {

    }
}