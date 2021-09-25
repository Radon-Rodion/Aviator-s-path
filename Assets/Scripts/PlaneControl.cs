using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour
{
	public GameObject planeRotate;
	public GameObject planeMove;
	public float speed = 1; //постоянная скорость горизонтального движения
	float alpha; //угол к вертикали (в рад)
	float beta; //угол по горизонтали (в рад) - за боковую скорость
	float gamma; //угол по фронтали (в рад) - за боковое ускорение
	public float power = 1; //скорость изменения вертикального угла
	
	public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)){ //угол к вертикали растёт
			if(alpha < 3) alpha += power* Time.deltaTime;
		} else { //угол к вертикали падает
			if(alpha > -3) alpha -= power* Time.deltaTime;
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)){ //угол к фронтали (боковое ускорение) растёт
			if(gamma < 3) gamma += power* Time.deltaTime;
			if(beta > -3) beta -= power* Time.deltaTime;
			//if((beta > -2 && gamma > 0 ) || (beta < 2 && gamma < 0)) beta -= gamma* power* Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.RightArrow)){ //угол к фронтали (боковое ускорение) падает
			if(gamma > -3) gamma -= power* Time.deltaTime;
			if(beta < 3) beta += power* Time.deltaTime;
			//if((beta > -2 && gamma > 0 ) || (beta < 2 && gamma < 0)) beta -= gamma* power* Time.deltaTime;
		}
		
		planeRotate.transform.rotation = Quaternion.Euler(-alpha*30, beta*30, gamma*30);
		/*planeMove.*/transform.Translate(Vector3.up * speed * alpha* Time.deltaTime);
		/*planeMove.*/transform.Translate(Vector3.right * speed * beta* Time.deltaTime);
		transform.Translate(Vector3.forward * speed* Time.deltaTime);
		
		shoot();
    }
	
	void shoot(){
		if(Input.GetMouseButtonDown(0)){
			GameObject bulletInstance = Instantiate(bullet, transform.position + new Vector3(0,0,2f), Quaternion.identity);
			bulletInstance.GetComponent<Rigidbody>().AddForce(planeRotate.transform.rotation * transform.forward * 5000);
		}
	}
}
