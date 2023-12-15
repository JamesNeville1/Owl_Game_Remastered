using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_spawner : MonoBehaviour {
    [Tooltip("Hold the locations where enemies can spawn")] [SerializeField]
    Transform[] spawnLocations;

    [System.Serializable]
    public struct waveTemp
    {
        [Tooltip("")]
        public SCO_enemy enemy;

        [Tooltip("")] [SerializeField]
        float timeBetweenSpawn;

        [Tooltip("")] [SerializeField]
        public int howMany;
    }

    [Tooltip("")] [SerializeField] int currentWave;
    [Tooltip("")] [SerializeField] waveTemp[] waves;

    void wave() {
        SCR_enemy enemyScript = returnEnemyScript(currentWave);

        int whichSpawner = UnityEngine.Random.Range(0, spawnLocations.Length);

        GameObject currentEnemy = returnEnemy(spawnLocations[whichSpawner].position, enemyScript);
    }

    GameObject returnEnemy(Vector2 pos, SCR_enemy enemyScript) {
        GameObject enemy = Instantiate(new GameObject(), pos, Quaternion.identity);
        SCR_enemy passedEnemyScript = enemy.AddComponent<SCR_enemy>();
        passedEnemyScript = enemyScript;
        return enemy;
    }

    SCR_enemy returnEnemyScript(int currentWave) { //Create a script for the instantiated enemy
        SCR_enemy enemyScript = new SCR_enemy();
        
        enemyScript.passedEnemySprite = waves[currentWave].enemy.enemySprite;
        enemyScript.passedDamage = waves[currentWave].enemy.damage;
        enemyScript.passedAttackAfterSeconds = waves[currentWave].enemy.attackAfterSeconds;
        enemyScript.passedAttackRadius = waves[currentWave].enemy.attackRadius;
        enemyScript.passedHealth = waves[currentWave].enemy.health;
        enemyScript.passedSpeed = waves[currentWave].enemy.speed;
        enemyScript.passedReward = waves[currentWave].enemy.reward;

        return enemyScript;
    }
}