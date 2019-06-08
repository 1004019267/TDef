using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T2 : TAll
{
    public Transform head;
    public Transform firePoint;
    LineRenderer line;
    public ParticleSystem lineEffect;

    public float attackRange = 3;
    public float attackRate = 1;
    public float atk = 1f;
    float attackInterval;
    float t;

    Transform target;
    int layermask;
    TAll tall;
    
    // Use this for initialization
    void Start()
    {
        line = this.GetComponent<LineRenderer>();
        attackInterval = 1f / attackRate;
        layermask = 1 << LayerMask.NameToLayer("Enemy");
        t = -attackInterval;
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(firePoint.position, firePoint.position + firePoint.forward * attackRange, Color.red);
        line.SetPosition(0, firePoint.position);
        line.SetPosition(1, firePoint.position + firePoint.forward * 3);
        if (canFire)
        {
            if (target == null)
            {
                Collider[] colls = Physics.OverlapSphere(transform.position, attackRange, layermask);
                if (colls.Length > 0)
                {
                    target = colls[0].transform;
                }
                line.SetPosition(0, firePoint.position);
                line.SetPosition(1, firePoint.position);
                lineEffect.Stop();
            }
            else
            {
                head.LookAt(target);
                float distance = Vector3.Distance(transform.position, target.position);
                if (distance > attackRange || target.GetComponent<Enemy>().IsAlive == false)
                {
                    target = null;
                }
                else
                {
                    if (Time.time - t > attackInterval)
                    {
                        t = Time.time;
                        Fire();
                    }
                    lineEffect.transform.position = target.position;
                }
            }
        }
    }

    protected override void Fire()
    {

        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, attackRange, layermask))
        {
            if (hit.collider.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<Enemy>().Hurt(atk*level);

                if (!lineEffect.isPlaying)
                {
                    lineEffect.Play();
                }
            }
        }

    }
}
