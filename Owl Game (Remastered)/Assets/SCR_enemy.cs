using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_enemy : MonoBehaviour {
    [Tooltip("")] [SerializeField]
    public Sprite passedEnemySprite;

    [Tooltip("")] [SerializeField]
    public float passedDamage;

    [Tooltip("")] [SerializeField]
    public float passedAttackAfterSeconds;

    [Tooltip("")] [SerializeField]
    public float passedAttackRadius;

    [Tooltip("")] [SerializeField]
    public float passedHealth;

    [Tooltip("")] [SerializeField]
    public float passedSpeed;

    [Tooltip("")] [SerializeField]
    public int passedReward;

    public void SCR_enemyConstructor(Sprite passedEnemySprite, float passedDamage, float passedAttackAfterSeconds, float passedAttackRadius, float passedHealth, float passedSpeed, int passedReward) {
        this.passedEnemySprite = passedEnemySprite;
        this.passedDamage = passedDamage;
        this.passedAttackAfterSeconds = passedAttackAfterSeconds;
        this.passedAttackRadius = passedAttackRadius;
        this.passedHealth = passedHealth;
        this.passedSpeed = passedSpeed;
        this.passedReward = passedReward;
    }

    private void Awake() {
        
    }

    private void Update() {
        
    }
}
