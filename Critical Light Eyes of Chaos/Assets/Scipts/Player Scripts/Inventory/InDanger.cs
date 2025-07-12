using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InDanger : MonoBehaviour
{
    public Player danger;
    public string typesofDanger;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (typesofDanger != "Boss") {
            if (danger.inDanger == true)
            {
                gameObject.SetActive(true);
            }
            if (danger.inDanger == false)
            {
                gameObject.SetActive(false);
            }

        }
        if (typesofDanger == "Boss")
        {
            danger.inDanger = true;

        }
        
        
    }
}
