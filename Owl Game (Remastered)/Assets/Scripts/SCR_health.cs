using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_health : MonoBehaviour {
    public Action onDeath;
    [Tooltip("")] [SerializeField]
    float health;

    public void adjust(float adjustBy) {
        health += adjustBy;
    }

    private void Update() {
        if(health <= 0) {
            if (onDeath != null) onDeath();
        }
    }
}
