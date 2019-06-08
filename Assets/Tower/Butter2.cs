using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butter2 : MonoBehaviour
{

    public float damage = 3;
    public float damageRange = 1.7f;
    public float time = 3f;
    public GameObject damageArea;
    // Use this fopur initialization
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube") || other.CompareTag("Plane"))
        {
            Vector3 point = this.transform.position;
            point.y = 0;
            var go = Instantiate(damageArea, point, Quaternion.identity);
            var aoe = go.GetComponent<Butter2Aoe>();
            aoe.damage = damage;
            aoe.time = time;
            aoe.size = damageRange;
            Destroy(gameObject);
        }

    }

}
