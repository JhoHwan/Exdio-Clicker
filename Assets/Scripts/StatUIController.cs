using UnityEngine;
using UnityEngine.UI;

public class StatUIController : MonoBehaviour
{
    [Header("UI Ref")] 
    [SerializeField] private Text goldText;
    [SerializeField] private Text damageText;
    [SerializeField] private Text criticalText;
    [SerializeField] private Text criticalDamageText;

    public void SetGoldText(int gold)
    {
        goldText.text = "Gold : " + gold;
    }
    
    public void SetDamageText(float damage)
    {
        damageText.text = "Damage : " + damage;
    }
    
    public void SetCriticalText(float critical)
    {
        criticalText.text = "Critical : " + critical + "%";
    }
    
    public void SetCriticalDamageText(float criticalDamage)
    {
        criticalDamageText.text = "Crit Dmg: " + (criticalDamage * 100) + "%";
    }
}