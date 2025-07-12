using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using System;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.ProBuilder;

public class itemSlot : MonoBehaviour, IPointerClickHandler
{
    //======Item Data=====//
    public string itemName;
    public int quantity;
    public UnityEngine.Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public UnityEngine.Sprite emptySprite;


    [SerializeField]
    private int maxNumberOfItems;

    //=====Item Slot=====//
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;

    
    //=====Item Description=====//
    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;

    //=====Misc=====//

    public GameObject selectedShader;
    public bool thisItemSelected;
    private InventoryManager inventoryManager;
    public Mesh [] allItems;
    
    private MeshFilter mFilter;

    private void Start()
    {
        inventoryManager = GameObject.Find("Inventory Canvas").GetComponent<InventoryManager>();
    }


    public int AddItem(string itemName, int quantity, UnityEngine.Sprite itemSprite, string itemDescription)
    {
        //Check to see if the slot is already full
        if(isFull)
        {
            return quantity;
        }
        //update name
        this.itemName = itemName;
        //update sprite
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        //update description
        this.itemDescription = itemDescription;
        //update quantity
        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = quantity.ToString();
            quantityText.enabled = true;
            isFull = true;

            // return the Leftovers
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }
        //Update Quantity Text
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;





    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }
    public void EmptySlot()
    {
        this.quantityText.enabled = false;
        this.itemImage.sprite = emptySprite;
        this.ItemDescriptionNameText.text = " ";
        this.ItemDescriptionText.text = " ";
        this.itemDescriptionImage.sprite = emptySprite;
        this.quantity = 0;
        print("RETIRED");
    }

    public void OnLeftClick()
    {
        if (thisItemSelected)
        {
            bool usable = inventoryManager.UseItem(itemName);
            
            if (usable && this.quantity > 0)
            {
                this.quantity -= 1;
                quantityText.text = this.quantity.ToString();
                if (this.quantity <= 0)
                {
                    EmptySlot();
                }
            }
            
        }


        else
        {
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
            ItemDescriptionNameText.text = itemName;
            ItemDescriptionText.text = itemDescription;
            itemDescriptionImage.sprite = itemSprite;
            if (itemDescriptionImage.sprite == null)
            {
                itemDescriptionImage.sprite = emptySprite;
            }
        }
    }

   

    public void OnRightClick()
    {
        if (this.quantity >= 1)
        {
            //Ceate a new Item
            GameObject itemToDrop = new GameObject(itemName);
            Item newItem = itemToDrop.AddComponent<Item>();
            newItem.quantity = 1;
            newItem.itemName = itemName;
            newItem.sprite = itemSprite;
            newItem.itemDescription = itemDescription;


            //Create and modifiy the MR
            MeshRenderer mr = itemToDrop.AddComponent<MeshRenderer>();
            mr.material = new Material(Shader.Find("Standard"));
            mr.material.mainTexture = itemSprite.texture;
            
          
            
            //Add a compoment(s)
            itemToDrop.AddComponent<BoxCollider>();
            itemToDrop.AddComponent<MeshFilter>();
            

            //Set the Location
            itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(1f, 0, 0);
            itemToDrop.transform.localScale = new Vector3(.5f, .5f, .5f);
            //mFilter.mesh = [Random.Range(0, allItems.Length)];

            //Subtract the item

            this.quantity -= 1;
            quantityText.text = this.quantity.ToString();
            if (this.quantity <= 0)
            {
                this.EmptySlot();
                
            }
        }

    }
}
