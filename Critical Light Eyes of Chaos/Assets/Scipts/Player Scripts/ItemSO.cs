using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public AttributeToChange attributeToChange = new AttributeToChange();
    public int amountToChangeAttribute;
    public PlayerMagicSystem playerMagicSystem;



    public bool UseItem()
    {
        if (statToChange == StatToChange.Health)
        {
            float currentHealth = GameObject.Find("Character").GetComponent<Player>().currentHealth;
            float maxHealth = GameObject.Find("Character").GetComponent<Player>().maxHealth;

            if (currentHealth == maxHealth)
            {
                return false;
            }
            else
            {
                GameObject.Find("Character").GetComponent<Player>().currentHealth += amountToChangeStat;
                return true;
            }

        }
        if (statToChange == StatToChange.Mana)
        {
           playerMagicSystem.currentMana += amountToChangeStat;
        }
        return false;
        
    }
    public enum StatToChange
    {
        None,
        Health,
        Mana
    };

    public enum AttributeToChange
    {
        None,
        Stregnth,
        Agility,
        ManaRegen,
        HealthRegen
    };
}
