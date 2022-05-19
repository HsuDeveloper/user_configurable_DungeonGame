using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private ItemSlot[] slots;

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<ItemSlot>();
    }
    void Awake()
    {
        FreshSlot();
    }
    public void FreshSlot()
    {
        int i = 0;
        for(; i< items.Count && i < slots.Length; i++) slots[i].item = items[i];

        for(;i < slots.Length; i++) slots[i].item = null;

    }

    public void AddItem(Item _item)
    {
        if(items.Count < slots.Length) 
        {
            items.Add(_item);
            FreshSlot();
        }

        else Debug.Log("inventory is full");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        List<Dictionary<string,object>> data = CSVReader.Read("inventory");

        for(int i=0;i<data.Count;i++)
        {
            items.Add(new Item((string)data[i]["item_name"] , (string)data[i]["item_sprite"]));
        }

        FreshSlot();
    }

}
