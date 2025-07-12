using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrantMagic : MonoBehaviour
{
    public MagicGranted magicGranted;
    public PlayerMagicSystem playerMagicSystem;
    public List<Spell> SpellGranted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grantable"))
        {
            if (magicGranted.magicType == "Fire")
            {
                playerMagicSystem.spellToCast = SpellGranted[0];
                print("Spell Granted");
                playerMagicSystem.enabled = true;
            }
        }
    }
}
