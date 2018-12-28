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

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log("Collision");
        //if (other.gameObject.name == "Tilemap")
        //{

        //}
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("CollisionEnemy");
            Debug.Log("PlayerDamage: " + Damage);
            Debug.Log("Effect: " + Effect);
            //other.gameObject.GetComponent<EnemyAI>().health -= Random.Range(0.75f, 1) * Damage; //.TakeDamage(Damage, Effect, true);
        }
        GameObject[] rina = GameObject.FindGameObjectsWithTag("Player");
        rina[0].GetComponent<SkillController>().resetSpell(this.transform.parent.name);
    }

    void DamageAndEffect(string name)
    {
        name = name.Replace("(Clone)", "");
        Debug.Log("DamageAndEffect: - " + name);
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
}
