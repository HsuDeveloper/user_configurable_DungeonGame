using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{

    private static DataManager _instance;
    public static DataManager instance{
        get{
            if(_instance == null) return null;
            return _instance;
        }
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
        SceneManager.LoadScene("main");
    }
    public void StartScene(){
        SceneManager.LoadScene("start");
    }
    // Start is called before the first frame update

}
