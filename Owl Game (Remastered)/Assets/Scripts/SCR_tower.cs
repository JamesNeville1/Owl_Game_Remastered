using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_tower : MonoBehaviour {
    SCR_unit unit;
    private void Start() {
        unit = GetComponent<SCR_unit>();
        unit.passive = towerPassive;
    }
    void towerPassive() { }
}
