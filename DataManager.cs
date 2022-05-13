using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class DataManager : MonoBehaviour
{

    private static DataManager _instance;
    public static DataManager instance{
        get{
            if(_instance == null) return null;
            return _instance;
        }
    }

    private GameObject _monster_pref;
    public GameObject monster_pref{
        get{return _monster_pref;}
        set{_monster_pref = value;}
    }
    private AsyncOperationHandle _monster_pref_handle;
    public AsyncOperationHandle monster_pref_handle{
        get{return _monster_pref_handle;}
        set{_monster_pref_handle = value;}
    }

    private int _monster_num;
    public int monster_num{
        get{ return _monster_num;}
        set{ _monster_num = value;}
    }
    private string _monster;
    public string monster{
        get{ return _monster;}
        set{ _monster = value;}
    }
    private int _rate_hp;
    public int rate_hp{
        get{ return _rate_hp;}
        set{ _rate_hp = value;}
    }
    private int _rate_atk;
    public int rate_atk{
        get{ return _rate_atk;}
        set{ _rate_atk = value;}
    }

    void Awake(){
        if(_instance == null){
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }
    }

    public void LoadGame (){
        Loading.LoadScene("main");
    }
    public void StartScene(){
        Loading.LoadScene("start");
        Addressables.Release(monster_pref_handle);
    }
    // Start is called before the first frame update

}
