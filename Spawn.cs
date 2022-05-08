using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject sword_man;
    public GameObject oneEye_monster;
    public GameObject goblin;
    public GameObject mushroom;
    private int population;
    Vector3 respawn_aria = new Vector3(2.3f,0.3f,0);
    Queue<int> unActive_pool;
    Enemy[] monster_pool;
    
    // Start is called before the first frame update
    void Start()
    {
        List<Dictionary<string,object>> data = CSVReader.Read("Monster_info");
        population = 5;
        monster_pool = new Enemy[population];
        unActive_pool = new Queue<int>();

        int monster_num = DataManager.instance.monster_num;

        for(int i=0;i<population;i++){
            GameObject monster = Instantiate(select_spawn_monster(monster_num));
            Enemy monster_state = monster.GetComponent<Enemy>();
            monster_state.spawnerObj = this;
            monster_state._num = i;
            monster_state._maxHp = (int)Mathf.Round((int)data[monster_num]["hp"] * DataManager.instance.rate_hp * 0.01f);
            monster_state._nowHp = monster_state._maxHp;
            monster_state._atkDmg = (int)Mathf.Round((int)data[monster_num]["atkDmg"] * DataManager.instance.rate_atk * 0.01f);
            monster_state.transform.position = respawn_aria;
            monster_state.gameObject.SetActive(false);
            monster_pool[i] = monster_state;
        }

        StartCoroutine(Spawn_monster());
        StartCoroutine(Respawn_monster());
    }

    GameObject select_spawn_monster(int n){
        switch(n){
            case 0:
            return sword_man;
            case 1:
            return oneEye_monster;
            case 2:
            return goblin;
            case 3:
            return mushroom;
        }
        
        return sword_man;
    }

    IEnumerator Spawn_monster(){
        foreach(Enemy monster in monster_pool){
            monster.gameObject.SetActive(true);

            yield return new WaitForSeconds(2f);
        }
    }
    public void Insert_monsterPool(int n){
        StartCoroutine(_Insert_monsterPool(n));
    }
    IEnumerator _Insert_monsterPool(int n){
        yield return new WaitForSeconds(1.5f);

        monster_pool[n].gameObject.SetActive(false);
        monster_pool[n]._nowHp = monster_pool[n]._maxHp;
        monster_pool[n].transform.position = respawn_aria;
        monster_pool[n]._alive = true;
        monster_pool[n].transform.rotation = Quaternion.identity;
        
        unActive_pool.Enqueue(n);
    }

    IEnumerator Respawn_monster(){
        while(true){
            if(unActive_pool.Count > 0 )
            {
                int n = unActive_pool.Dequeue();
                monster_pool[n].gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(1f);
        }
    }

}


