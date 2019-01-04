using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillColliderController : MonoBehaviour
{
    private float Damage = 0f;
    private string Effect = "";

    // Use this for initialization
    void Start()
    {
        DamageAndEffect(this.transform.parent.name);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("CollisionEnemy");
            Debug.Log("PlayerDamage: " + Damage);
            Debug.Log("Effect: " + Effect);
            other.gameObject.GetComponent<EnemyAI>().health -= Random.Range(0.75f, 1) * Damage; //.TakeDamage(Damage, Effect, true);
            if (Effect != "" && !other.gameObject.GetComponent<EnemyAI>().effected)
                StartCoroutine(EffectToOrc(Effect, other));
        }
        GameObject[] rina = GameObject.FindGameObjectsWithTag("Player");
        rina[0].GetComponent<SkillController>().resetSpell(this.transform.parent.name);
    }

    void DamageAndEffect(string name)
    {
        name = name.Replace("(Clone)", "");
        //Debug.Log("DamageAndEffect: - " + name);
        switch (name)
        {
            case "Cosmic":
                Damage = 20f;
                Effect = "";
                break;
            case "FlameRing":
                Damage = 30f;
                Effect = "fire";
                break;
            case "Halo":
                Damage = 25f;
                Effect = "";
                break;
            case "Ice":
                Damage = 15f;
                Effect = "ice";
                break;
            case "Light":
                Damage = 15f;
                Effect = "";
                break;
            case "Mystery":
                Damage = 35f;
                Effect = "";
                break;
            case "Poison":
                Damage = 20f;
                Effect = "poison";
                break;
            case "ToxicCloud":
                Damage = 25f;
                Effect = "poison";
                break;
        }
    }

    IEnumerator EffectToOrc(string effectName, GameObject other) // Damage to enemy with special effects
    {
        switch (effectName)
        {
            case "poison":
                for (int a = 0; a < 10; a++)
                {
                    yield return new WaitForSeconds(3);
                    other.gameObject.GetComponent<EnemyAI>().health -= Random.Range(0.75f, 1) * 4; // 3 seconds - 10 times - 4 damage
                }
                break;
            case "ice":
                float walkingSpeed = other.gameObject.GetComponent<EnemyAI>().walkingSpeed;
                float runSpeed = other.gameObject.GetComponent<EnemyAI>().runSpeed;
                other.gameObject.GetComponent<EnemyAI>().walkingSpeed = walkingSpeed / 2;
                other.gameObject.GetComponent<EnemyAI>().runSpeed = runSpeed / 2;
                yield return new WaitForSeconds(10);
                other.gameObject.GetComponent<EnemyAI>().walkingSpeed = walkingSpeed;
                other.gameObject.GetComponent<EnemyAI>().runSpeed = runSpeed;
                break;
            case "fire":
                for (int a = 0; a < 5; a++)
                {
                    yield return new WaitForSeconds(2);
                    other.gameObject.GetComponent<EnemyAI>().health -= Random.Range(0.75f, 1) * 10; // 2 seconds - 5 times - 10 damage
                }
                break;
        }
        other.gameObject.GetComponent<EnemyAI>().effected = false;
    }
}
