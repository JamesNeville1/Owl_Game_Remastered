using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyPreset", menuName = "ScriptableObjects/Enemies")]
public class SCO_enemy : ScriptableObject {
    [Tooltip("Ensure pivot is in the bottom centre for expected results")]
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

    [Tooltip("How many points the player should be awarded.\nPlayer uses points to create and upgrade towers.")]
    public int reward;
}
