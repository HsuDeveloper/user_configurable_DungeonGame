using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Play : MonoBehaviour
{
    AsyncOperationHandle handle;
    public Button start_btn;
    public Dropdown monster_set;
    public Dropdown hp_set;
    public Dropdown atk_set;
    public Image monster_preview;
    public Text info;
    private int monster_num;
    private string monster;
    private int rate_hp;
    private int rate_atk;

    void monsterChange(){
        monster_num = monster_set.value;
        monster = monster_set.options[monster_num].text;

        DataManager.instance.monster_num = monster_num;
        DataManager.instance.monster = monster;

        Addressables.LoadAssetAsync<Sprite>(monster+ "_sprite").Completed +=
        (AsyncOperationHandle<Sprite> Obj) =>
        {
            handle = Obj;
            monster_preview.sprite = Obj.Result;
        };
    }
    void hpChange(){
        rate_hp = int.Parse(hp_set.options[hp_set.value].text.Substring(0,3));
        DataManager.instance.rate_hp = rate_hp;
    }
    void atkChange(){
        rate_atk = int.Parse(atk_set.options[atk_set.value].text.Substring(0,3));
        DataManager.instance.rate_atk = rate_atk;
    }

    void Start(){
        monsterChange();
        hpChange();
        atkChange();

        start_btn.onClick.AddListener(delegate{
            DataManager.instance.LoadGame();
        });

        monster_set.onValueChanged.AddListener(delegate{
            monsterChange();
        });
        hp_set.onValueChanged.AddListener(delegate{
            hpChange();
        });
        atk_set.onValueChanged.AddListener(delegate{
            atkChange();
        });
    }
}
