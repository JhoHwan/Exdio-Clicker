using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private HpBar hpBar;
    [SerializeField] private float maxHp;
    private float curHp;

    private bool isDead = false;
    private Animator animator;

    private void Awake()
    {
        curHp = maxHp;
        animator = GetComponent<Animator>();
    }

    public void OnHit(float damage)
    {
        curHp -= damage;
        if (curHp <= 0)
        {
            curHp = 0;
            isDead = true;
        }
        animator.SetTrigger("Hit");
        Debug.Log("Slime Hit!, Current Hp : " + curHp);
        hpBar.ChangeHpBarAmount(curHp / maxHp);

        if(isDead) 
        {
            Debug.Log("Slime is Dead");
            animator.SetTrigger("Death");
            Destroy(gameObject, 1.5f);
        }
    }
}
