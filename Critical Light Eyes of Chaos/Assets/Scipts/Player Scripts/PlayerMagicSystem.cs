using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
    [SerializeField] public Spell spellToCast;
    [SerializeField] public Spell spellToCast2;
    [SerializeField] public Spell spellToCast3;
    [SerializeField] public Spell spellToCast4;
    [SerializeField] public Spell spellToCast5;

    [SerializeField] private float maxMana = 100f;
    [SerializeField] public float currentMana = 100f;
    [SerializeField] private float manaRechargeRate = 2f;
    [SerializeField] private float timeToWaitForRecharge = 2f;
    private float currentManaRechargeTimer;
    [SerializeField] private float magicCooldown;
    [SerializeField] private float magicCooldown2;
    [SerializeField] private float magicCooldown3;
    [SerializeField] private float magicCooldown4;
    [SerializeField] private float magicCooldown5;
    private float currentCastTimer;
    public ManaBar manaBar;

    [SerializeField] private Transform castPoint;

    [SerializeField] private Transform UpwardcastPoint;

    private bool castingMagic= false;
    private bool castingMagic2 = false;
    private bool castingMagic3 = false;
    private bool castingMagic4 = false;
    private bool castingMagic5 = false;

    private PlayerMovement playerMovement;
    public ManaBar manabar;
   

    private void Awake()
    {
        playerMovement = new PlayerMovement();
        currentMana = maxMana;

        magicCooldown = spellToCast.spellToCast.Cooldown;
        magicCooldown2 = spellToCast2.spellToCast.Cooldown;
        magicCooldown3 = spellToCast3.spellToCast.Cooldown;
        magicCooldown4 = spellToCast4.spellToCast.Cooldown;
        magicCooldown5 = spellToCast5.spellToCast.Cooldown;
    }

   

    private void Update()
    {
        bool isSpellCastHeldDown = Input.GetButtonDown("Spell 1");
        bool hasEnoughMana = currentMana - spellToCast.spellToCast.manaCost >= 0;
        if (!castingMagic && isSpellCastHeldDown && hasEnoughMana)
        {
            castingMagic = true;
            currentMana -= spellToCast.spellToCast.manaCost;
            manaBar.SetMana(currentMana);
            currentCastTimer = 0;
            currentManaRechargeTimer = 0;
            CastSpell();
        }
        if (castingMagic)
        {
            currentCastTimer += Time.deltaTime;
            
            if (currentCastTimer > magicCooldown) castingMagic = false;
        }

        if (currentMana <= maxMana && !castingMagic && !isSpellCastHeldDown)
        {
            currentManaRechargeTimer += Time.deltaTime;

            if (currentManaRechargeTimer > timeToWaitForRecharge)
            {
                currentMana += manaRechargeRate * Time.deltaTime;
                manaBar.SetMana(currentMana);
                if (currentMana > maxMana) currentMana = maxMana;
            }
        }

        bool isSpellCastHeldDown2 = Input.GetButtonDown("Spell 2");
        bool hasEnoughMana2 = currentMana - spellToCast2.spellToCast.manaCost >= 0;
        if (!castingMagic2 && isSpellCastHeldDown2 && hasEnoughMana2)
        {
            castingMagic2 = true;
            currentMana -= spellToCast2.spellToCast.manaCost;
            manaBar.SetMana(currentMana);
            currentCastTimer = 0;
            currentManaRechargeTimer = 0;
            CastSpell();
        }
        if (castingMagic2)
        {
            currentCastTimer += Time.deltaTime;

            if (currentCastTimer > magicCooldown2) castingMagic2 = false;
        }

        if (currentMana <= maxMana && !castingMagic2 && !isSpellCastHeldDown2)
        {
            currentManaRechargeTimer += Time.deltaTime;

            if (currentManaRechargeTimer > timeToWaitForRecharge)
            {
                currentMana += manaRechargeRate * Time.deltaTime;
                manaBar.SetMana(currentMana);
                if (currentMana > maxMana) currentMana = maxMana;
            }
        }

        bool isSpellCastHeldDown3 = Input.GetButtonDown("Spell 3");
        bool hasEnoughMana3 = currentMana - spellToCast3.spellToCast.manaCost >= 0;
        if (!castingMagic3 && isSpellCastHeldDown3 && hasEnoughMana3)
        {
            castingMagic3 = true;
            currentMana -= spellToCast3.spellToCast.manaCost;
            manaBar.SetMana(currentMana);
            currentCastTimer = 0;
            currentManaRechargeTimer = 0;
            CastSpell();
        }
        if (castingMagic3)
        {
            currentCastTimer += Time.deltaTime;

            if (currentCastTimer > magicCooldown3) castingMagic3 = false;
        }

        if (currentMana <= maxMana && !castingMagic3 && !isSpellCastHeldDown3)
        {
            currentManaRechargeTimer += Time.deltaTime;

            if (currentManaRechargeTimer > timeToWaitForRecharge)
            {
                currentMana += manaRechargeRate * Time.deltaTime;
                manaBar.SetMana(currentMana);
                if (currentMana > maxMana) currentMana = maxMana;
            }
        }

        bool isSpellCastHeldDown4 = Input.GetButtonDown("Spell 4");
        bool hasEnoughMana4 = currentMana - spellToCast3.spellToCast.manaCost >= 0;
        if (!castingMagic4 && isSpellCastHeldDown4 && hasEnoughMana4)
        {
            castingMagic4 = true;
            currentMana -= spellToCast4.spellToCast.manaCost;
            manaBar.SetMana(currentMana);
            currentCastTimer = 0;
            currentManaRechargeTimer = 0;
            CastSpell();
        }
        if (castingMagic)
        {
            currentCastTimer += Time.deltaTime;

            if (currentCastTimer > magicCooldown4) castingMagic4 = false;
        }

        if (currentMana <= maxMana && !castingMagic4 && !isSpellCastHeldDown4)
        {
            currentManaRechargeTimer += Time.deltaTime;

            if (currentManaRechargeTimer > timeToWaitForRecharge)
            {
                currentMana += manaRechargeRate * Time.deltaTime;
                manaBar.SetMana(currentMana);
                if (currentMana > maxMana) currentMana = maxMana;
            }
        }

        bool isSpellCastHeldDown5 = Input.GetButtonDown("ULTIMATE SPELL");
        bool hasEnoughMana5 = currentMana - spellToCast5.spellToCast.manaCost >= 0;
        if (!castingMagic5 && isSpellCastHeldDown5 && hasEnoughMana5)
        {
            castingMagic5 = true;
            currentMana -= spellToCast5.spellToCast.manaCost;
            manaBar.SetMana(currentMana);
            currentCastTimer = 0;
            currentManaRechargeTimer = 0;
            CastSpell();
        }
        if (castingMagic5)
        {
            currentCastTimer += Time.deltaTime;

            if (currentCastTimer > magicCooldown5) castingMagic5 = false;
        }

        if (currentMana <= maxMana && !castingMagic5 && !isSpellCastHeldDown5)
        {
            currentManaRechargeTimer += Time.deltaTime;

            if (currentManaRechargeTimer > timeToWaitForRecharge)
            {
                currentMana += manaRechargeRate * Time.deltaTime;
                manaBar.SetMana(currentMana);
                if (currentMana > maxMana) currentMana = maxMana;
            }
        }
    }
    void CastSpell()
    {
        if (Input.GetButtonDown("Spell 1"))
        {
            if (spellToCast.spellToCast.isUpwardsSpell == true)
            {
                Instantiate(spellToCast, UpwardcastPoint.position, castPoint.rotation);
            } else
            {
                Instantiate(spellToCast, castPoint.position, castPoint.rotation);
            }
        }

        if (Input.GetButtonDown("Spell 2"))
        {
            if (spellToCast2.spellToCast.isUpwardsSpell == true)
            {
                Instantiate(spellToCast2, UpwardcastPoint.position, castPoint.rotation);
            }
            else
            {
                Instantiate(spellToCast2, castPoint.position, castPoint.rotation);
            }
        }

        if (Input.GetButtonDown("Spell 3"))
        {
            if (spellToCast3.spellToCast.isUpwardsSpell == true)
            {
                Instantiate(spellToCast3, UpwardcastPoint.position, castPoint.rotation);
            }
            else
            {
                Instantiate(spellToCast3, castPoint.position, castPoint.rotation);
            }
        }

        if (Input.GetButtonDown("Spell 4"))
        {
            if (spellToCast4.spellToCast.isUpwardsSpell == true)
            {
                Instantiate(spellToCast4, UpwardcastPoint.position, castPoint.rotation);
            }
            else
            {
                Instantiate(spellToCast4, castPoint.position, castPoint.rotation);
            }
        }

        if (Input.GetButtonDown("ULTIMATE SPELL"))
        {
            if (spellToCast5.spellToCast.isUpwardsSpell == true)
            {
                Instantiate(spellToCast5, UpwardcastPoint.position, castPoint.rotation);
            }
            else
            {
                Instantiate(spellToCast5, castPoint.position, castPoint.rotation);
            }
        }
    }
}
