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

    //Make array/dictionary of enemy temps

    private void Start() {
        wave(0);
        wave(1);
    }

    void wave(int currentWave) {
        int whichSpawner = UnityEngine.Random.Range(0, spawnLocations.Length);

        GameObject currentEnemy = returnEnemy(spawnLocations[whichSpawner].position, currentWave);
    }

    GameObject returnEnemy(Vector2 pos, int currentWave) {
        GameObject enemy = Instantiate(new GameObject(), pos, Quaternion.identity);
       
        SCR_enemy script = enemy.AddComponent<SCR_enemy>();
        script.SCR_enemyConstructor(
            waves[currentWave].enemy.enemySprite,
            waves[currentWave].enemy.damage,
            waves[currentWave].enemy.attackAfterSeconds,
            waves[currentWave].enemy.attackRadius,
            waves[currentWave].enemy.health,
            waves[currentWave].enemy.speed,
            waves[currentWave].enemy.reward);
        return enemy;
    }
}