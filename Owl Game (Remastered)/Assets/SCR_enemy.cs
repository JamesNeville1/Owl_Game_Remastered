using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_enemy : MonoBehaviour {
    [Tooltip("")][SerializeField]
    public Sprite passedEnemySprite;

    [Tooltip("")][SerializeField]
    public float passedDamage;

    [Tooltip("")][SerializeField]
    public float passedAttackAfterSeconds;

    [Tooltip("")][SerializeField]
    public float passedAttackRadius;

    [Tooltip("")][SerializeField]
    public float passedHealth;

    [Tooltip("")][SerializeField]
    public float passedSpeed;

    [Tooltip("")][SerializeField]
    public int passedReward;

    [Tooltip("")] [SerializeField]
    SCR_health target;

    public void SCR_enemyConstructor(Sprite passedEnemySprite, float passedDamage, float passedAttackAfterSeconds, float passedAttackRadius, float passedHealth, float passedSpeed, int passedReward) {
        this.passedEnemySprite = passedEnemySprite;
        this.passedDamage = passedDamage;
        this.passedAttackAfterSeconds = passedAttackAfterSeconds;
        this.passedAttackRadius = passedAttackRadius;
        this.passedHealth = passedHealth;
        this.passedSpeed = passedSpeed;
        this.passedReward = passedReward;
    }

    void Awake() {

    }
    void Start() {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = passedEnemySprite;
        sr.flipX = passedSpeed < 0 ? true : false;
    }
    void Update() {
        transform.position += (Vector3)new Vector2(passedSpeed, 0) * Time.deltaTime;
    }
    void enemyMain() {
        if(target == null) {

        }
    }
}
