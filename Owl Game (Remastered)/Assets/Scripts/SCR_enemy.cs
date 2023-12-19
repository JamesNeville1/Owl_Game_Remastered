using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

    [Tooltip("")] [SerializeField] [SCR_utils.custom_attributes.ReadOnly]
    SCR_health target;

    SCR_timer myTimer;

    public void SCR_enemyConstructor(Sprite passedEnemySprite, float passedDamage, float passedAttackAfterSeconds, float passedAttackRadius, float passedHealth, float passedSpeed, int passedReward) {
        this.passedEnemySprite = passedEnemySprite;
        this.passedDamage = passedDamage;
        this.passedAttackAfterSeconds = passedAttackAfterSeconds;
        this.passedAttackRadius = passedAttackRadius;
        this.passedHealth = passedHealth;
        this.passedSpeed = passedSpeed;
        this.passedReward = passedReward;
    }
    void Start() {
        //
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = passedEnemySprite;
        sr.flipX = passedSpeed < 0 ? true : false;

        //
        gameObject.GetComponentInChildren<CircleCollider2D>().radius = passedAttackRadius;

        //
        myTimer = SCR_timer.create(() => attack(), passedAttackAfterSeconds, gameObject, false);
    }
    void Update() {
        enemyMain();
    }
    void enemyMain() {
        if (target == null) {
            passive();
        }
        else {
            if(!myTimer.continueLoop) myTimer.resetSelf();
        }
    }
    void passive() {
        transform.position += (Vector3)new Vector2(passedSpeed, 0) * Time.deltaTime;
    }
    void attack() {
        if(target.check()) target.adjust(-passedDamage);
    }
    void OnTriggerEnter2D(Collider2D collision) {
        collision.TryGetComponent(out SCR_health t);
        if(t != null) {
            target = t;
        }
    }
}
