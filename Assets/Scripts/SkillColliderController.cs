using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillColliderController : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collision");
        if (other.gameObject.name == "Tilemap")
        {
            SkillController.resetSpell(this.transform.parent.name);
        }
    }
}
