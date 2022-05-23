using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;
    [SerializeField] Sprite[] itemImgs;

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private ItemSlot[] slots;

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
        slots = slotParent.GetComponentsInChildren<ItemSlot>();

        List<Dictionary<string,object>> data = CSVReader.Read("inventory");

        for(int i=0;i<data.Count;i++)
        {
            Sprite itemImg = itemImgs[(int)data[i]["item_num"]];
            AddItem(new Item((int)data[i]["item_num"] , (int)data[i]["item_type"],itemImg));
        }

    }

}
