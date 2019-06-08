using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butter : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().Hurt(2);
            Destroy(this.gameObject);
        }
    }
}
