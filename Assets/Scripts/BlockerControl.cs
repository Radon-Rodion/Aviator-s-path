using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerControl : MonoBehaviour
{
	delegate void MovementDelegate(Vector3 speed);
	
	MovementDelegate moveType;
	public int moveTp;
	public Vector3 moveSpeed;
	public float jerkTime = 1;
	float t;
	
    // Start is called before the first frame update
    void Start()
    {
        switch(moveTp){
			case 1:
				t = jerkTime;
				moveType = moveSmoothy;
				break;
			case 2:
				moveType = moveJerkly;
				t = jerkTime;
				break;
			default:
				moveType = stay;
				break;
		}
		
		
    }

    // Update is called once per frame
    void Update()
    {
        moveType(moveSpeed);
    }
	
	void stay(Vector3 speed){}
	
	void moveSmoothy(Vector3 speed){
		if(t<0){
			directionControl();
			t = jerkTime;
		} else t-= Time.deltaTime;
		transform.Translate(speed * Time.deltaTime);
	}
	
	void moveJerkly(Vector3 speed){
		if(t<0){
			directionControl();
			transform.Translate(speed.normalized * 6);
			t = jerkTime;
		} else t-= Time.deltaTime;
	}
	
	void directionControl(){
		if(transform.position.x < -11.5 || transform.position.x > 11.5 
		|| transform.position.y < -4.5 || transform.position.y > 4.5){
			moveSpeed *= -1;
		}
	}
}
