using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{
    private SphereCollider myCollider;
    private Rigidbody myRigidbody;
    public SpellScripitibleObject spellToCast;
    

    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = spellToCast.SpellRadius;

        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;

        Destroy(this.gameObject, spellToCast.lifeTime);

    }

    public void Update()
    {
        
       if (spellToCast.isUpwardsSpell == true)
        {
            if (spellToCast.speed > 0) transform.Translate(Vector3.up * spellToCast.speed * Time.deltaTime);
        } else
        {
            if (spellToCast.speed > 0) transform.Translate(Vector3.forward * spellToCast.speed * Time.deltaTime);
        }
    }
       

    private void OnTriggerEnter(Collider other)
    {
        // Apply spell effects to whatever we hit
        //Apply hit particles
        // Apply sound effects
        if (other.gameObject.CompareTag("Enemy") || (other.gameObject.CompareTag("Boss")))
        {
            HealthComponent enemyHealth = other.GetComponent<HealthComponent>();
            enemyHealth.TakeDamage(spellToCast.damage);
        }
        
        if (spellToCast.isLingeringSpell == false)
        {
            Destroy(this.gameObject);
        }

       
        
    }
}
