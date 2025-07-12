using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public string itemName;

    [SerializeField]
    public int quantity;

    [SerializeField]
    public Sprite sprite;

    [TextArea]
    [SerializeField]
    public string itemDescription;

    private InventoryManager inventoryManager;
    private itemSlot slot;
    public int itemValue;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("Inventory Canvas").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
         
            int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            if(leftOverItems <= 0)
            {
                Destroy(gameObject);
   
               
                
            } else
            {
                quantity = leftOverItems;
            }
           
        }
    }
}
