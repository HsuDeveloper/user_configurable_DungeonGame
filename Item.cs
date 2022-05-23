using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public int num;
    public int type;
    public Sprite itemImg;

    public Item(int _num, int _type,Sprite _itemImg){
        num = _num;
        type = _type;
        itemImg = _itemImg;
    }
}
