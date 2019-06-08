using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHp : MonoBehaviour
{

    Transform target;
     Slider progress;
    public Vector3 offset = new Vector3(0, 40, 0);
    // Use this for initialization
    void Start()
    {
        progress = this.GetComponent<Slider>();
    }
    public void Init(Transform obj)
    {
        target = obj;
    }
    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 point = Camera.main.WorldToScreenPoint(target.position);
            transform.position = point + offset;
        }
        
    }
    public void SetHpPercent(float p)
    {
        progress.value = p;
    }
}
