using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public Transform[] points;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void OnDrawGizmos()
    {
        for (int i = 0; i < points.Length-1; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(points[i].position, points[i + 1].position);
        }
    }
    public Vector3 GetPoint(int index)
    {
        index = Mathf.Clamp(index, 0, points.Length - 1);
        return points[index].position;
    }
    public int Length
    {
        get
        {
            return points.Length;
        }
    }
}
