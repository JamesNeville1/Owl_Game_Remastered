using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_base : MonoBehaviour {
    void Start() {
        GetComponent<SCR_health>().onDeath = () => baseDeath();
    }
    void baseDeath() {
        Debug.Log("Game is lost");
        Destroy(gameObject);
    }
}
