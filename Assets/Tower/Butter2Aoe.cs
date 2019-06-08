using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butter2Aoe : MonoBehaviour
{
    public float damage = 3;
    public float time = 3;
    public float size = 1.7f;
    public float delataDamage;
    float t;    
    // Use this for initialization
    void Start()
    {
        delataDamage = damage / time * Time.fixedDeltaTime;
        Destroy(this.gameObject, 3f);      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var cols = Physics.OverlapBox(transform.position, Vector3.one * size);
        for (int i = 0; i < cols.Length; i++)
        {
            var enemy = cols[i].GetComponent<Enemy>();
            if (enemy)
            {                            
              StartCoroutine(enemy.waitSlow());                          
                enemy.Hurt(delataDamage);
            }
        }
    }

}
