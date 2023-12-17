using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_health : MonoBehaviour {
    [Tooltip("")] [SerializeField]
    float health;

    public void adjust(float adjustBy) {
        health += adjustBy;
        Debug.Log("Health is now " + health);
    }
}
