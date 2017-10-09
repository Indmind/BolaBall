using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour {

    public float speed;
    
	// Update is called once per frame
	void Update () {
        Vector3 curPos = transform.position;
        if(curPos[0] <= -20 || curPos[0] >= -5)
        {
            speed = -(speed);
        }
        transform.position = new Vector3(curPos[0] + speed, curPos[1], curPos[2]);
	}
}
