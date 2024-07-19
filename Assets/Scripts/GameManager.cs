using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private Monster[] slimes;
    
    [Header("Stat")]
    [SerializeField] private float damage;
    [SerializeField] private float criticalChance;
    [SerializeField] private float criticalDamage;
    private int gold;


    private StatUIController statUIController;
    private Monster curSlime;

    private void Awake()
    {
        statUIController = FindObjectOfType<StatUIController>();
        statUIController.SetGoldText(gold);
        statUIController.SetDamageText(damage);
        statUIController.SetCriticalText(criticalChance);
        statUIController.SetCriticalDamageText(criticalDamage);
    }

    private void SpawnSlime()
    {
        int spawnIndex = UnityEngine.Random.Range(0, slimes.Length);
        GameObject newSlime = Instantiate(slimes[spawnIndex].gameObject);
        curSlime = newSlime.GetComponent<Monster>();
    }

    private void Update()
    {
        if (curSlime == null)
        {
            SpawnSlime();
        }
    }

    private bool CheckCritical()
    {
        float rand = UnityEngine.Random.Range(0.0f, 100.0f);
        if (criticalChance > rand)
        {
            Debug.Log("Critical");
            return true;
        }
        return false;
    }

    public void GetGold()
    {
        gold += curSlime.Gold;
        statUIController.SetGoldText(gold);
    }

    public void HitSlime()
    {
        if (curSlime.IsDead || curSlime == null) return;
        float calDamage = this.damage;
        
        if (CheckCritical()) 
            calDamage *= criticalDamage;
        curSlime.OnHit(calDamage);
        
        if (curSlime.IsDead)
        {
            GetGold();
        }
    }
}