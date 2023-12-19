using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_enemy : MonoBehaviour {
    SCR_unit unit;
    float passedSpeed;
    private void Start() {
        unit = GetComponent<SCR_unit>();
        unit.passive = enemyPassive;
        passedSpeed = unit.passedSpeed;
    }
    void enemyPassive() {
        transform.position += (Vector3)new Vector2(passedSpeed, 0) * Time.deltaTime;
    }
}
