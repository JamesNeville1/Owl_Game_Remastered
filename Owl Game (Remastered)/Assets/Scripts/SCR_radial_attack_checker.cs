using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_radial_attack_checker {
    public static SCR_radial_attack_checker radialAttackChecker(Action action, GameObject parent = null) {
        SCR_radial_attack_checker newChecker = new SCR_radial_attack_checker(action);
        GameObject obj = new GameObject("My Radial Attack Checker", typeof(hook));
        obj.GetComponent<hook>().onTrig = newChecker.action;

        return newChecker;
    }
    class hook : MonoBehaviour {
        public Action onTrig;
        private void OnTriggerEnter2D(Collider2D collision) {
            onTrig();
        }
    }
    Action action;
    SCR_radial_attack_checker(Action action) {
        this.action = action;
    }
}
