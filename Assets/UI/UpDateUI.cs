using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpDateUI : MonoBehaviour {
    TAll curTAll;
  public  Button updataBtn;
  public  Button destroyBtn;
    public Transform panel;
    
    public void Awake()
    {
        updataBtn.onClick.AddListener(OnUpdateClick);
        destroyBtn.onClick.AddListener(OnDestroyClick);
        //遮罩被点击，隐藏面板
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => {
            this.gameObject.SetActive(false);
        });
    }
public void SetUpdate(TAll tAll)
    {
        curTAll = tAll;
        //修改UI的显示位置和炮塔一致
        panel.position = Camera.main.WorldToScreenPoint(tAll.transform.position);
        //判断金币是否足够升级
        if (MyHp.Instance.HasMoney(tAll.UpdateCost()))
        {
            updataBtn.interactable = true;
        }
        else
        {
            updataBtn.interactable = false;
        }
    }

    public void OnUpdateClick()
    {
        MyHp.Instance.Addmoney(-curTAll.UpdateCost());
        curTAll.Addlevel();
        curTAll = null;
        this.gameObject.SetActive(false);
    }
    public void OnDestroyClick()
    {
        curTAll.Destroy();
        MyHp.Instance.Addmoney(curTAll.PayBack());
        curTAll = null;
        this.gameObject.SetActive(false);
    }
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
