using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LevelSon {
    //一波多少兵
    public GameObject []prefabs;
    //间隔
    public float interval = 1;
    public float num = 5;
    int count;
    float t;
    Level level;
    public int enemylevel = 1;
    public bool isNum;
	// Use this for initialization
	void Start () {
      
	}

   public void SetLevel(int val)
    {
        enemylevel = val;
    }

    public bool UpdateSpawn()
    {
        if (count>=num)
        {
            isNum = false;
            return false;
        }
        if (Time.timeSinceLevelLoad-t>interval)
        {
            t = Time.timeSinceLevelLoad;
            count++;
            Level.Instance.CreatEnemy(prefabs[UnityEngine.Random.Range(0, prefabs.Length)],enemylevel);
        }
        isNum = true;
        return true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
