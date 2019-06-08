using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAll : MonoBehaviour {
   protected bool canFire;
    public int spend;//创建需要金币
    protected int level;//等级，升级金币=level*cost
    public GameObject owner;
    // Use this for initialization
    public void Init(int _spend,int _level,GameObject _owner)
    {
        spend = _spend;
        level = _level;     
        canFire = true;
        owner = _owner;//保存Cube用
    }
    public void Addlevel()
    {
        level++;
    }
    public int UpdateCost()
    {
        return level * spend+spend;
    }
    public int PayBack()
    {       
        return level * spend /2;
    }
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    protected virtual void Fire()
    {

    }
        
    
    public void SetMoney(int money)
    {
        spend = money;
    }
   public virtual void Destroy()
    {
        owner.layer = LayerMask.NameToLayer("Floor");
        Destroy(this.gameObject);
    }
}
