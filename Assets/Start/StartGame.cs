using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartGame : MonoBehaviour {
    Button starBtn;
	// Use this for initialization
	void Start () {
        starBtn = transform.Find("Start").GetComponent<Button>();
        starBtn.onClick.AddListener(OnStartClick);
	}
	void OnStartClick()
    {
        Application.LoadLevel(1);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
