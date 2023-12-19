using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SCR_unit : MonoBehaviour {
    [Tooltip("")][SerializeField] [SCR_utils.custom_attributes.ReadOnly]
    public Sprite passedEnemySprite;

    [Tooltip("")][SerializeField] [SCR_utils.custom_attributes.ReadOnly]
    public float passedDamage;

    [Tooltip("")][SerializeField] [SCR_utils.custom_attributes.ReadOnly]
    public float passedAttackAfterSeconds;

    [Tooltip("")][SerializeField] [SCR_utils.custom_attributes.ReadOnly]
    public float passedAttackRadius;

    [Tooltip("")][SerializeField] [SCR_utils.custom_attributes.ReadOnly]
    public float passedHealth;

    [Tooltip("")][SerializeField] [SCR_utils.custom_attributes.ReadOnly]
    public float passedSpeed;

    [Tooltip("")][SerializeField] [SCR_utils.custom_attributes.ReadOnly]
    public int passedReward;

    [Tooltip("")] [SerializeField] [SCR_utils.custom_attributes.ReadOnly]
    SCR_health target;

    [Tooltip("")] [SerializeField]
    string targetTag;

    SCR_timer myTimer;

    public Action passive;

    public void SCR_unitConstructor(Sprite passedEnemySprite, float passedDamage, float passedAttackAfterSeconds, float passedAttackRadius, float passedHealth, float passedSpeed, int passedReward = 0) {
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
        myTimer = SCR_timer.create(() => SCR_utils.functions.attack(passedDamage), passedAttackAfterSeconds, gameObject, false);

        //
        SCR_health myHealth = GetComponent<SCR_health>();
        myHealth.health = passedHealth;
        myHealth.onDeath = unitDeath;
    }
    void Update() {
        unitMain();
    }
    void unitMain() {
        if (target == null) {
            passive();
        }
        else {
            if(!myTimer.continueLoop) myTimer.resetSelf();
        }
    }
    void unitDeath() {
        //Do vfx
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == targetTag) {
            collision.TryGetComponent(out SCR_health t);
            if (t != null) {
                target = t;
                myTimer.action = () => SCR_utils.functions.attack(passedDamage, target);
            }
        }
    }
}
