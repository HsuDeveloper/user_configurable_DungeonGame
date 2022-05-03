using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Spawn spawnerObj;
    private Animator animator;
    private int num;
    public int _num{
        get{return num;}
        set{num = value;}
    }
    // to check working well
    [SerializeField]
    private int maxHp;
    public int _maxHp{
        get{return maxHp;}
        set{maxHp = value;}
    }
    private int nowHp;
    public int _nowHp{
        get{return nowHp;}
        set{nowHp = value;}
    }
    private bool alive=true;
    public bool _alive{
        get{return alive;}
        set{alive = value;}
    }
    [SerializeField]
    private int atkDmg;
    public int _atkDmg{
        get{return atkDmg;}
        set{atkDmg = value;}
    }
    private float atkSpeed = 1;

    void SetAttackSpeed(float speed)
    {
        animator.SetFloat("attackSpeed", speed);
        atkSpeed = speed;
    }


    public void Damaged(int d){
        if(nowHp <= 0) return;
        nowHp -= d;

        if(nowHp <= 0){
            animator.SetBool("life",false);
            alive=false;
            Die();
        }
    }

    public void Die(){
        spawnerObj.Insert_monsterPool(this.num);
    }

    // Start is called before the first frame update
    void Start()
    { 
        animator = GetComponent<Animator>();

        SetAttackSpeed(1.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!alive) return;
        if(animator.GetBool("life") == false) animator.SetBool("life",true);
        
        if(transform.position.x > 0){
            animator.SetBool("is_moving",true);
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        else{
            animator.SetBool("is_moving",false);
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")){
                animator.SetTrigger("attack");
            }
        }  

    }
}