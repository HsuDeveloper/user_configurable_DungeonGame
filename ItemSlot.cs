using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Image image;
    private Item _item;
    public Item item
    {
        get{return _item;}
        set{
            if(_item != null)
            {
                image.sprite = _item.itemImage;
                image.color = new Color(1,1,1,1);
            }
            else
            {
                image.color = new Color(1,1,1,0);
            }
        }
    }
    
}
