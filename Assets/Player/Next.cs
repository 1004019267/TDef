using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Next : MonoBehaviour {
    Button neBtn;
    // Use this for initialization
    void Start () {
        neBtn = GameObject.Find("End/Button").GetComponent<Button>();
        neBtn.onClick.AddListener(OnNextScenceClick);
        transform.SetAsLastSibling();    
    }

    private void OnNextScenceClick()
    {
        Application.LoadLevel(1);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
