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
}
