using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    private HpBar _hpBar;
    private SlimeNameText _nameText;
    [SerializeField] private string monsterName;
    [SerializeField] private float maxHp;
    [SerializeField] private int gold;
    public int Gold => gold;
    private float curHp;

    public bool IsDead { get; private set; }
    private Animator animator;
    private GameManager gameManager;

    private void Start()
    {
        curHp = maxHp;
        animator = GetComponent<Animator>();
        _nameText = GetComponentInChildren<SlimeNameText>();
        _hpBar = GetComponentInChildren<HpBar>();
        
        _nameText?.SetNameText(monsterName);
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnHit(float damage)
    {
        if (IsDead) return;
        curHp -= damage;
        if (curHp <= 0)
        {
            curHp = 0;
            IsDead = true;
        }
        animator.SetTrigger("Hit");
        Debug.Log("Slime Hit!, Current Hp : " + curHp);
        _hpBar.ChangeHpBarAmount(curHp / maxHp);

        if(IsDead) 
        {
            Debug.Log("Slime is Dead");
            animator.SetTrigger("Death");
            Destroy(gameObject, 1.5f);
        }
    }
}
