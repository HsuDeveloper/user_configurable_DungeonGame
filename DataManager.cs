using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class DataManager : MonoBehaviour
{
    public GameObject datamanager;
    public Character character;
    public Inventory inventory;
    private static DataManager _instance;
    private GameObject _monster_pref;
    private AsyncOperationHandle _monster_pref_handle;
    private int _monster_num;
    private string _monster;
    private int _rate_hp;
    private int _rate_atk;
    private int _weapon;

    public static DataManager instance
    {
        get
        {
            if(_instance == null) return null;
            return _instance;
        }
    }
    
    public GameObject monster_pref
    {
        get{return _monster_pref;}
        set{_monster_pref = value;}
    }
    
    public AsyncOperationHandle monster_pref_handle
    {
        get{return _monster_pref_handle;}
        set{_monster_pref_handle = value;}
    }
    
    public int monster_num
    {
        get{ return _monster_num;}
        set{ _monster_num = value;}
    }
    
    public string monster
    {
        get{ return _monster;}
        set{ _monster = value;}
    }
    
    public int rate_hp
    {
        get{ return _rate_hp;}
        set{ _rate_hp = value;}
    }
    
    public int rate_atk
    {
        get{ return _rate_atk;}
        set{ _rate_atk = value;}
    }
    public int weapon
    {
        get{return _weapon;}
        set{_weapon = value;}
    }

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void LoadGame ()
    {
        Loading.LoadScene("main");
    }
    public void StartScene()
    {
        Loading.LoadScene("start");
        Addressables.Release(monster_pref_handle);
    }
}
