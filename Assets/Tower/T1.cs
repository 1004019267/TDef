using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1 : TAll
{
    public Transform head;
    public Transform firePoint;
    public GameObject buttetPrefab;

    public float attackRange=3;
    public float attackRate=1;
    public float speed = 200;

    float attackInterval;
    float t;

    Transform target;
    int layermask;
   

   

    // Use this for initialization
    void Start()
    {      
        attackInterval = 1f / attackRate;
        layermask = 1 << LayerMask.NameToLayer("Enemy");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (canFire)
        {
            if (target == null)
            {
                Collider[] colls = Physics.OverlapSphere(transform.position, attackRange, layermask);
                if (colls.Length > 0)
                {
                    target = colls[0].transform;
                }
            }
            else
            {
                head.LookAt(target);
                float distance = Vector3.Distance(transform.position, target.position);
                if (distance > attackRange || target.GetComponent<Enemy>().IsAlive == false)
                {
                    target = null;
                }
                if (Time.time - t > attackInterval/level)
                {
                    t = Time.time;
                    Fire();
                }
            }
        }


    }
    protected override  void Fire()
    {
        var go = Instantiate(buttetPrefab, firePoint.position, firePoint.rotation);
        go.GetComponent<Rigidbody>().velocity = firePoint.forward * speed * Time.deltaTime;
    }
  
}
