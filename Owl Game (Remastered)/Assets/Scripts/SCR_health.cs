using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_health : MonoBehaviour {
    public Action onDeath;

    [Tooltip("")]
    public float health;

    public void adjust(float adjustBy) {
        health += adjustBy;
    }

    public bool check() {
        return (health <= 0) ? false : true;
    }

    private void Update() {
        if(health <= 0) {
            if (onDeath != null) onDeath();
        }
    }
}
