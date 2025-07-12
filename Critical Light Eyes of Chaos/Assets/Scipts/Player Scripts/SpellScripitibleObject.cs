using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Spell", menuName = "Spells")]
public class SpellScripitibleObject : ScriptableObject
{
    public float damage = 10f;
    public float manaCost = 5f;
    public float lifeTime = 2f;
    public float speed = 15f;
    public float SpellRadius = 0.5f;
    public string damageType;
    public float Cooldown;
    public bool isLingeringSpell;
    public bool isUpwardsSpell;
    //status effects
    //UI Thumbnail
    //Magic elements
}
