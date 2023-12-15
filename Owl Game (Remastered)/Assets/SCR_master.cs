using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_master : MonoBehaviour {
    [Tooltip("Count the quantity of enemies, lets the game know when it can run the next game")] [SerializeField]
    int enemyQuantity = 0;

    private void Awake() {
        enemyQuantity = 0;
    }
}
