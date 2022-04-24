using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Enemy enemy;
    private int population;
    Vector3 respawn_aria = new Vector3(2.1f,3f,0);
    Queue<int> unActive_pool;
    Enemy[] monster_pool;
    
    // Start is called before the first frame update
    void Start()
    {
        population = 5;
        monster_pool = new Enemy[population];
        unActive_pool = new Queue<int>();

        for(int i=0;i<population;i++){
            Enemy monster = Instantiate(enemy);
            monster.spawnerObj = this;
            monster._num = i;
            monster.gameObject.SetActive(false);
            monster_pool[i] = monster;
        }

        StartCoroutine(Spawn_monster());
        StartCoroutine(Respawn_monster());
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


