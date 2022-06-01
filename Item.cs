using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int num;
    public int type;
    public int dmg;
    public Sprite itemImg;

    public Item(int _num, int _type,int _dmg,Sprite _itemImg){
        num = _num;
        type = _type;
        dmg = _dmg;
        itemImg = _itemImg;
    }
}
