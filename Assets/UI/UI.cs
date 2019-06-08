using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject T;
    bool press;
    Transform turretObj;
    Transform lastCube;
    bool isT1 = true;
    bool isT2 = true;
    public int cost = 4;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (MyHp.Instance.HasMoney(cost))
        {
            press = true;
            turretObj = Instantiate(T).transform;
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (press)
        {
            press = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, 1 << 8))
            {
                turretObj.position = hit.collider.transform.position;
                turretObj.GetComponent<TAll>().Init(cost,1,hit.collider.gameObject);
                turretObj = null;
                hit.transform.gameObject.layer = LayerMask.NameToLayer("Default");
                GetMoney.moneyAdd(-cost);
            }
            else
            {
                Destroy(turretObj.gameObject);
                turretObj = null;
            }
            if (lastCube)
            {
                //上一个Cube恢复颜色
                lastCube.GetComponent<MeshRenderer>().material.color = Color.white;

            }
        }

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (press)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layermask = 1 << 8 | 1 << 0;
            if (Physics.Raycast(ray, out hit, 100, layermask))
            {
                turretObj.position = hit.point;
                if (hit.collider.CompareTag("Cube"))
                {
                    if (lastCube)
                    {
                        //上一个Cube恢复颜色
                        lastCube.GetComponent<MeshRenderer>().material.color = Color.white;

                    }
                    //当前Cube变红
                    lastCube = hit.transform;
                    lastCube.GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
        }


    }
}
