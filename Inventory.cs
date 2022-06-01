using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<Item> itemList;
    [SerializeField] Sprite[] weaponImgs;
    private int currList;

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private ItemSlot[] slots;
    public List<Dictionary<string,object>> data;

    public Button weapon_tab; //currList == 0 
    public Button helmet_tab; //currList == 1
    public Button body_tab; //currList == 2
    public Button etc_tab; // currList == 3

    public void FreshSlot()
    {
        int i = 0;
        for(; i< itemList.Count && i < slots.Length; i++) slots[i].item = itemList[i];

        for(;i < slots.Length; i++) slots[i].item = null;

    }

    public void AddItem(Item _item)
    {
        if(itemList.Count < slots.Length) 
        {
            itemList.Add(_item);
        }

        else Debug.Log("inventory is full");
    }

    public void ChangeTab(int n)
    {
        currList = n;
        itemList.Clear();
        for(int i=0;i<data.Count;i++)
        {
            int item_num = (int)data[i]["item_num"];
            int item_type = (int)data[i]["item_type"];
            int item_dmg = (int)data[i]["item_dmg"];

            if(item_type != currList) continue;

            Sprite itemImg = weaponImgs[(int)data[i]["item_num"]];
            
            AddItem(new Item(item_num, item_type, item_dmg, itemImg));
            
        }
        FreshSlot();
    }
    // Start is called before the first frame update
    void Start()
    {

        slots = slotParent.GetComponentsInChildren<ItemSlot>();

        data = CSVReader.Read("inventory");

        ChangeTab(0);

    }

}
