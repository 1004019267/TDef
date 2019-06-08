using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RePlay : MonoBehaviour {
    Button reBtn;
	// Use this for initialization
	void Start () {
        reBtn = GameObject.Find("Lost/Button").GetComponent<Button>();
        reBtn.onClick.AddListener(OnNextScenceClick);
        transform.SetAsLastSibling();
	}
	
	// Update is called once per frame
    public void OnNextScenceClick()
    {
        Time.timeScale = 1;
        Application.LoadLevel(1);
        
    }
	void Update () {
        
	}
}
