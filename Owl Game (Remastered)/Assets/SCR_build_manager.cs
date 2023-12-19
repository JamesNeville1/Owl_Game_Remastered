using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_build_manager : MonoBehaviour {
    
    [Tooltip("")] [SerializeField]
    SCO_unit test;
    
    [Tooltip("")] [SerializeField]
    GameObject towerTemplate;

    GameObject returnTower(Vector2 pos, bool lookLeft) {
        GameObject tower = Instantiate(towerTemplate, pos, Quaternion.identity);

        SCR_unit script = tower.GetComponent< SCR_unit>();
        script.SCR_unitConstructor(
            test.enemySprite,
            test.damage,
            test.attackAfterSeconds,
            test.attackRadius,
            test.health,
            lookLeft is true ? test.speed : -test.speed);
        return tower;
    }

    private void Start() {
        returnTower(new Vector2(4, -9), true);
        returnTower(new Vector2(-4, -9), false);
    }
}