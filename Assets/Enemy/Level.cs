using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("波次设置")]
    //工厂唯一静态实例
    public static Level Instance;
    [Tooltip("出生点")]
    public Transform bornPoint;
    // Use this for initialization
    //波次
    [Tooltip("波次")]
    public LevelSon[] prefabs;
    private Queue<LevelSon> queue = new Queue<LevelSon>();
    [Tooltip("波次间隔")]
    public float levelInterval = 15;
    float t;
    int enemycount=0;
    UILook uiLook;
    int count=1;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        uiLook = FindObjectOfType<UILook>();
        foreach (var item in prefabs)
        {
            queue.Enqueue(item);//入队
        }
        t = -levelInterval;
        StartCoroutine(CheckWin());
    }
    IEnumerator CheckWin()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (GameWin())
            {
                uiLook.End();
                Time.timeScale = 0;
                yield break;//携程内部打断
            }
        }
    }
    void Update()
    {
        if (queue.Count > 0)
        {            
            if (Time.timeSinceLevelLoad - t > levelInterval)
            {
                   
                LevelSon son = queue.Peek();//看对头
                son.SetLevel(prefabs.Length-queue.Count+1);
                if (son.isNum==true)
                {
                    uiLook.SetNums(count);
                }
                
                if (!son.UpdateSpawn())//出本波兵
                {
                    count++;                 
                    //笨波出兵完成
                    queue.Dequeue();//出队
                    t = Time.timeSinceLevelLoad;
                }
            }
        }
    }
    // Update is called once per frame
    public void CreatEnemy(GameObject prefab,int level)
    {
        var go = Instantiate(prefab);
        go.transform.position = bornPoint.position;
        go.GetComponent<Enemy>().enemyLevel = level;
        enemycount++;
       
    }
    public void EnemyDead()
    {
        enemycount--;
    }
    bool GameWin()
    {
        if (queue.Count==0&&enemycount==0)
        {
            return true;
        }
        return false;
    }
}
