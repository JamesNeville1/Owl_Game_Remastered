using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyPreset", menuName = "ScriptableObjects/Enemies")]
public class SCO_enemy : ScriptableObject {
    [Tooltip("")]
    public Sprite enemySprite;

    [Tooltip("")]
    public float damage;

    [Tooltip("")]
    public float attackAfterSeconds;

    [Tooltip("")]
    public float attackRadius;

    [Tooltip("")]
    public float health;

    [Tooltip("")] 
    public float speed;

    [Tooltip("")]
    public int reward;
}
