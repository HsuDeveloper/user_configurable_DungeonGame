using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Enemy sword_man;
    public Enemy oneEye_monster;
    private int population;
    Vector3 respawn_aria = new Vector3(2.3f,0.3f,0);
    Queue<int> unActive_pool;
    Enemy[] monster_pool;
    
    // Start is called before the first frame update
    void Start()
    {
        List<Dictionary<string,object>> data = CSVReader.Read("Monster_setting");
        population = 5;
        monster_pool = new Enemy[population];
        unActive_pool = new Queue<int>();

        int monster_num = DataManager.instance.monster_num;

        for(int i=0;i<population;i++){
            Enemy monster = Instantiate(select_spawn_monster(monster_num));
            monster.spawnerObj = this;
            monster._num = i;
            monster._maxHp = (int)Mathf.Round((int)data[monster_num]["hp"] * DataManager.instance.rate_hp * 0.01f);
            monster._nowHp = monster._maxHp;
            monster._atkDmg = (int)Mathf.Round((int)data[monster_num]["atkDmg"] * DataManager.instance.rate_atk * 0.01f);
            monster.transform.position = respawn_aria;
            monster.gameObject.SetActive(false);
            monster_pool[i] = monster;
        }

        StartCoroutine(Spawn_monster());
        StartCoroutine(Respawn_monster());
    }

    Enemy select_spawn_monster(int n){
        switch(n){
            case 0:
            return sword_man;
            case 1:
            return oneEye_monster;
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


