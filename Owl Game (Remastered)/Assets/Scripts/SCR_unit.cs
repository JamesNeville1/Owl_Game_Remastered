using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Diagnostics;

public class SCR_unit : MonoBehaviour {
    [Header("Require Dev Action")]
    [Tooltip("The target this unit is looking for")] [SerializeField]
    string targetTag;

    [Header("Read Only")]
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

    //Can't be searlised anyway
    SCR_timer myTimer;

    public Action passive;

    SCR_attack_checker.radialChecker checker;

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

        //Determine Attack Type
        if (true) {
            checker = SCR_attack_checker.radialChecker.create(passedAttackRadius, targetTag, gameObject);
        }
        else if (false) {

        }

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
        target = checker.returnTarget();
        if (target == null) {
            passive();
        }
        else {
            if(!myTimer.continueLoop) myTimer.resetSelf();
            myTimer.action = () => SCR_utils.functions.attack(passedDamage, target);
        }
    }
    void unitDeath() {
        //Do vfx
        Destroy(this.gameObject);
    }
}
