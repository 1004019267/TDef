using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MyHp : MonoBehaviour
{
    public static MyHp Instance;
    public int hp = 10;
    public int myGold = 10;
    UILook uiLook;
    Level level;
    // Use this for initialization
    void Start()
    {
        Instance = this;
        uiLook = GameObject.FindObjectOfType<UILook>();
        GetMoney.moneyAdd += this.Addmoney;
        transform.SetAsLastSibling();
        level = FindObjectOfType<Level>();
    }
    public bool HasMoney(int value)
    {
        return value <= myGold;
    }
    private void OnDestroy()
    {
        GetMoney.moneyAdd -= this.Addmoney;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && hp > 0)
        {
            hp -= other.GetComponent<Enemy>().atk;
            if (hp <= 0)
            {
                uiLook.LoseOn();
                Time.timeScale = 0;
            }
            uiLook.SetHp(hp);
            level.EnemyDead();
            Destroy(other.GetComponent<Enemy>().hpUI.gameObject);
            Destroy(other.gameObject);
        }
    }
    public void Addmoney(int gold)
    {
        myGold += gold;
        uiLook.SetGold(myGold);
    }
   
}
