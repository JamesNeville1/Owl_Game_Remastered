using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SCR_spawner : MonoBehaviour {
    [Tooltip("Hold the locations where enemies can spawn")] [SerializeField]
    Transform[] spawnLocations;

    [System.Serializable]
    public struct waveTemp {
        [Tooltip("")]
        public SCO_unit enemy;

        [Tooltip("")] [SerializeField]
        public float timeBetweenSpawn;

        [Tooltip("")] [SerializeField]
        public int howMany;
    }

    //[Tooltip("")] [SerializeField]
    //bool finished;
    [Tooltip("Hold which wave the game is currently on")] [SerializeField]
    [SCR_utils.custom_attributes.ReadOnly]
    int currentWave;
    [Tooltip("")] [SerializeField]
    waveTemp[] waves;
    [Tooltip("")] [SerializeField]
    GameObject enemyTemplate;

    //Make array/dictionary of enemy temps

    void Awake() {
        //finished = false;
    }
    void Start() {
        StartCoroutine(wave(0));
    }
    IEnumerator wave(int currentWave) {
        for (int i = 0; i < waves[currentWave].howMany; i++) {
            yield return new WaitForSeconds(waves[currentWave].timeBetweenSpawn);
            singleEnemy(waves[currentWave].enemy, currentWave);
        }
        //finished = true;
    }
    void singleEnemy(SCO_unit enemy, int currentWave) {
        int whichSpawner = UnityEngine.Random.Range(0, spawnLocations.Length);

        GameObject currentEnemy = returnEnemy(spawnLocations[whichSpawner].position, currentWave, whichSpawner is 0? true : false);
    }

    GameObject returnEnemy(Vector2 pos, int currentWave, bool goingLeft) {
        GameObject enemy = Instantiate(enemyTemplate, pos, Quaternion.identity);

        SCR_unit script = enemy.GetComponent<SCR_unit>();
        script.SCR_unitConstructor(
            waves[currentWave].enemy.enemySprite,
            waves[currentWave].enemy.damage,
            waves[currentWave].enemy.attackAfterSeconds,
            waves[currentWave].enemy.attackRadius,
            waves[currentWave].enemy.health,
            goingLeft is true ? waves[currentWave].enemy.speed : -waves[currentWave].enemy.speed,
            waves[currentWave].enemy.reward);
        return enemy;
    }
}