using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public Button play_btn;
    public Dropdown monster_set;
    public Dropdown hp_set;
    public Dropdown atk_set;
    public Image monster_img;
    public Text info;
    public string monster;
    public int rate_hp;
    public int rate_atk;
    
    static Play _instance;

    public static Play instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Play>();
            }
            return _instance;
        }
    }

    void Awake(){
        DontDestroyOnLoad(this);
    }

    public void LoadGame (){
        SceneManager.LoadScene("main");
    }

    void monsterChange(){
        monster = monster_set.options[monster_set.value].text;
    }
    void hpChange(){
        rate_hp = int.Parse(hp_set.options[hp_set.value].text.Substring(0,3));
    }
    void atkChange(){
        rate_atk = int.Parse(atk_set.options[atk_set.value].text.Substring(0,3));
    }
    void Start(){
        monsterChange();
        hpChange();
        atkChange();

        play_btn.onClick.AddListener(delegate{
            LoadGame();
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
