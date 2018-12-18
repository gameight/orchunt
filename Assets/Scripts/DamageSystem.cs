using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour {

    [SerializeField] int level = 1;
    public static float Damage = 0; //Orc's damage to player
    public static float Health = 0; //Orc's health
    public static float Armor = 0; //Reduce player damage to orc
    private float Speed = 20f; //Orc's speed

    private void Start()
    {
        CalculateStats();

    }

    void CalculateStats()
    {
        Damage = 10 * (level * 0.5f) + 5;   // 10-15-20-25-...
        Health = 10 * level + 40;           // 50-60-70-80-...      
        Armor = level * 1.5f;               // 1.5-3-4.5-6-...
    }

    public void TakeDamage(float PlayerDamage, string skillEffectName, bool ArmorProtection)
    {
        float TakenDamage;

        if (ArmorProtection)
            TakenDamage = PlayerDamage - Armor;
        else
            TakenDamage = PlayerDamage;

        Debug.Log("Damage taken: " + TakenDamage);

        if (TakenDamage > 0)
            Health = Health - TakenDamage;

        if (skillEffectName != "")
            SkillEffect(skillEffectName);

        Debug.Log("Health:" + Health);

        if (Health <= 0)
            Destroy(this);
    }

    void SkillEffect(string effectName)
    {
        switch (effectName)
        {
            case "ice":
                StartCoroutine(IceEffect());
                break;
            case "fire":
                StartCoroutine(FireEffect());
                break;
            case "poison":
                StartCoroutine(PoisonEffect());
                break;
            default:
                break;
        }
    }

    IEnumerator IceEffect() {
        EnemyAI.speed = EnemyAI.speed / 2;
        yield return new WaitForSeconds(5);
        EnemyAI.speed = EnemyAI.speed * 2;
    }

    IEnumerator FireEffect()
    {
        for(int a = 0; a < 3; a++)
        {
            TakeDamage(5, "", true);
            yield return new WaitForSeconds(2);
        }
    }

    IEnumerator PoisonEffect()
    {
        for (int a = 0; a < 10; a++)
        {
            TakeDamage(2, "", false);
            yield return new WaitForSeconds(1);
        }
    }
}
