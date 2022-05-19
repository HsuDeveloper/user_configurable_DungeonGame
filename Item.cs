using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : MonoBehaviour
{
    public string itemName;
    public Sprite itemImage;

    public Item(string _itemName,string _itemImage){
        itemName = _itemName;
        
    }
}
