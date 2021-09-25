using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonControl : MonoBehaviour
{
	public float movementTime = 1;
	float t; Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.up;
		t = movementTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(t > 0){
			 t-= Time.deltaTime;
			 baloonMove();
		} else {
			direction *= -1;
			t = movementTime;
		}
    }
	
	void baloonMove(){
		transform.Translate(direction * Time.deltaTime);
	}
}
