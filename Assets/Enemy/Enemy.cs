using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public GameObject explodePrefab;   
    public GameObject hpPrefab;
    [NonSerialized]
    public EnemyHp hpUI;
    public float hp = 5;
    public NavMeshAgent agent;
    float speed;
    public float t;
    float speedp = 0.3f;
    public int atk = 2;
    public int gold1;
    public static int gold;
    bool isSlow = false;
    Level level;
   float nowhp;
    public int enemyLevel = 1;
    // Use this for initialization
    void Start()
    {
        hp = hp * Mathf.Pow(1.2f, enemyLevel);
        nowhp = hp;
        level = FindObjectOfType<Level>();
        agent = GetComponent<NavMeshAgent>();
        speed = agent.speed * 0.4f;
        gold = gold1*enemyLevel;
        var go = Instantiate(hpPrefab);
        go.transform.SetParent(UILook.Instance.canvas.transform);
       hpUI= go.GetComponent<EnemyHp>();
        hpUI.Init(this.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool IsAlive
    {
        get
        {
            if (hp > 0)
            {
                return true;
            }
            return false;
        }

    }

    public void Hurt(float value)
    {
        hp -= value;      
        hpUI.SetHpPercent(hp / nowhp);
        hp = hp <= 0 ? 0 : hp;
        if (hp == 0)
        {
            agent.GetComponent<Collider>().enabled = false;
            var go = Instantiate(explodePrefab, transform.position, transform.rotation);
            Destroy(go, 1f);
            GetMoney.moneyAdd(gold);
            level.EnemyDead();
            Destroy(hpUI.gameObject);
            Destroy(this.gameObject);
        }
    }

    public IEnumerator waitSlow()
    {
        if (isSlow == false)
        {
            isSlow = true;
            agent.speed = speed;
        }
        yield return new WaitWhile(delegate ()
        {
            t += Time.deltaTime;
            if (t > 3)
            {
                return false;
            }
            return true;
        });
        if (agent != null)
        {
            agent.speed = speed / 0.4f;
            isSlow = false;
        }
    }

}
