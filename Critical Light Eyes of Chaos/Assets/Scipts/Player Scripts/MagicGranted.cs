using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicGranted : MonoBehaviour
{
    public GrantMagic grantMagic;
    public string magicType = "";
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
        if (other.gameObject.CompareTag("Player"))
        {
            if(magicType == "Fire")
            {
                grantMagic.playerMagicSystem.spellToCast = grantMagic.SpellGranted[0];
                grantMagic.playerMagicSystem.enabled = true;
            }
            
        }
    }
}
