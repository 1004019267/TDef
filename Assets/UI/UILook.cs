using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UILook : MonoBehaviour {
    public static UILook Instance;
    [System.NonSerialized]
    public  Canvas canvas;
    Text hpText;
    Text goldText;
    GameObject end;
    GameObject Lose;
    Text numText;
    public UpDateUI updateUI;
	// Use this for initialization
	void Start () {
        Instance = this;
        canvas = this.GetComponent<Canvas>();
        numText= transform.Find("Score").GetComponent<Text>();
        hpText = transform.Find("HP/Text").GetComponent<Text>();
        goldText = transform.Find("Gold/Text").GetComponent<Text>();
        end = transform.Find("End").gameObject;
        Lose = transform.Find("Lost").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layer = 1 << LayerMask.NameToLayer("Tower");
            if (Physics.Raycast(ray, out hit, 100, layer))
            {
                updateUI.gameObject.SetActive(true);
                updateUI.SetUpdate(hit.collider.GetComponent<TAll>());

            }
        }
    }
    public void SetHp(int hp)
    {
        hpText.text = "" + hp;
    }
    public void SetGold(int gold)
    {
        goldText.text = "" + gold;
    }
    public void SetNums(int nums)
    {
        numText.text = "第" + nums + "波";
    }
    public void End()
    {
        end.SetActive(true);
    }
    public void LoseOn()
    {
        Lose.SetActive(true);
    }
    public void NumOn()
    {
        numText.gameObject.SetActive(false);
    }
}
