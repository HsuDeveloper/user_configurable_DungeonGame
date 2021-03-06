using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{

    Animator animator;
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public int weaponDmg;
    public int atkPos = 0;
    public int weaponRange;
    [SerializeField] GameObject[] weapons;
    private int weapon = 0;
    public float atkSpeed = 1;
    public bool start_flag = false;

    BoxCollider2D weaponCollider;
    public BoxCollider2D weaponRange1;
    public BoxCollider2D weaponRange2;
    public BoxCollider2D weaponRange3;

    void SetAttackSpeed(float speed)
    {
        animator.SetFloat("atkSpeed", speed);
        atkSpeed = speed;
    }

    void switchWeapon_range(int wr)
    {
        weaponCollider.enabled=false;

        switch(wr){
            case 1:
            weaponCollider = weaponRange1;
            break;
            case 2:
            weaponCollider = weaponRange2;
            break;
            case 3:
            weaponCollider = weaponRange3;
            break;
        }
        
        weaponCollider.enabled=true;

    }

    public void switchWeapon(int w, int dmg)
    {
        atkDmg -= weaponDmg;
        atkDmg += dmg;
        weapons[weapon].SetActive(false);
        weapons[w].SetActive(true);
        weapon = w;
        weaponDmg = dmg;
    }

    // Start is called before the first frame update
    void Start()
    {
        List<Dictionary<string,object>> data = CSVReader.Read("Character_info");
        weapon = (int)data[0]["weapon"];
        weapons[weapon].SetActive(true);
        maxHp = 100;
        nowHp = 100;
        atkDmg = 10;
        weaponDmg = (int)DataManager.instance.inventory.data[weapon]["item_dmg"];
        atkDmg += weaponDmg;

        weaponCollider = weaponRange1;

        switchWeapon_range(1);
        
        animator = GetComponent<Animator>();

        SetAttackSpeed(1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(weaponCollider.transform.position,weaponCollider.transform.localScale,0);
        
        if(collider2Ds.Length>1)
        {
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Character_attack")&&!animator.GetCurrentAnimatorStateInfo(0).IsName("Character_attack2")){

                if(atkPos == 0)
                {
                    animator.SetTrigger("attack_1");
                    atkPos = 1; 
                    
                }
                else if(atkPos ==1)
                {
                    animator.SetTrigger("attack_2");
                    atkPos = 0;
                }

                foreach(Collider2D collider in collider2Ds)
                {
                        if(collider.tag == "Enemy")
                        {
                            collider.GetComponent<Enemy>().Damaged(atkDmg);
                        }
                    }
            }
        }
    }
}
