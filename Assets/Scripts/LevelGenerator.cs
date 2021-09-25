using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	public GameObject[] blockers;
	public GameObject[] borders;
	public GameObject[] baloons;
	public GameObject[] sharps;

	int z;
	public int startZ;
	
	void Start(){
		generateLevel();
	}
	
	
	private void generateLevel(){
		z = startZ+10; //координата начала размещения объектов на уровне
		while(z < startZ + 85){
			int type = Random.Range (0, 2); //0 - blockers, 1 - baloons, 2 - sharps
			generateLevelPart(type);
		}
	}
	
	private void generateLevelPart(int type){
		switch(type){
			case 0:
				generateBlockers();
				break;
			case 1:
				generateBaloons();
				break;
			case 2:
				generateSharps();
				break;
		}
	}
	
	private void generateBlockers(){
		int zadavatel = Random.Range(0, 23);//2 - hor/Vert; 2 - large/small; 2 - with/without borders; 3 - movement types
		int[] zQuefs; //множители жля получения у (х) координаты по z
		
		if((zadavatel/2)%2 == 0){ //мелкие блоки
			zQuefs = new int[] {-1, 0, 1}; //последовательно по диагонали
		} else {//крупные блоки
			zQuefs = new int[] {1, -1, 1}; //в шахматном порядке
		}
		if(zadavatel>11){ //горизонтальные блоки
			if(zadavatel%2==0 && z<startZ + 75){ //ограничение пространства (вертикальное)
				Instantiate (borders[1], new Vector3(0,0,z+9), Quaternion.identity);
			}
			setHorBlockers(zQuefs, /*2*/zadavatel%3%2, (zadavatel/2)%2);
			
		} else { //вертикальные блоки
			if(zadavatel%2==0 && z<startZ + 75){  //ограничение пространства (горизонтальное)
				Instantiate (borders[0], new Vector3(0,0,z+9), Quaternion.identity);
			}
			setVertBlockers(zQuefs, /*2*/zadavatel%3%2, (zadavatel/2)%2);
		}
	}
	
	private void setHorBlockers(int[] zQuefs, int moveType, int blockerWidth){
		int random2 = Random.Range(0,1);
		if(random2 == 0) for(int i=0; i<zQuefs.Length; i++) zQuefs[i] *= -1; //зеркальное отражение
		
		for(int i=0; i < 3; i++){
			if(z > startZ + 85) break;
			GameObject blocker = Instantiate(blockers[2+blockerWidth], new Vector3(0, zQuefs[i]*4, z), Quaternion.identity);
			blocker.GetComponent<BlockerControl>().moveTp = moveType;
			blocker.GetComponent<BlockerControl>().moveSpeed = new Vector3(0, Random.Range(1,2)/2f, 0);
			
			z+=10;
		}
	}
	
	private void setVertBlockers(int[] zQuefs, int moveType, int blockerWidth){
		int random2 = Random.Range(0,1);
		if(random2 == 0) for(int i=0; i<zQuefs.Length; i++) zQuefs[i] *= -1; //зеркальное отражение
		
		for(int i=0; i < 3; i++){
			if(z > startZ + 85) break;
			GameObject blocker = Instantiate(blockers[blockerWidth], new Vector3(zQuefs[i]*10.5f, 0, z), Quaternion.identity);
			blocker.GetComponent<BlockerControl>().moveTp = moveType;
			blocker.GetComponent<BlockerControl>().moveSpeed = new Vector3(Random.Range(1,3)/2f, 0, 0);
			
			z+=10;
		}
	}
	
	private void generateBaloons(){
		int random2 = Random.Range(0,1);
		Instantiate(baloons[random2], new Vector3(0, 0, z), Quaternion.identity);
		z += 5;
		if(z<=startZ + 85) {
			Instantiate(baloons[(random2+1)%2], new Vector3(0, 0, z), Quaternion.identity);
			z += 5;
		}
	}
	
	private void generateSharps(){
		for(int i=0; i<2; i++){
			if(z < startZ + 85){
				Instantiate(sharps[Random.Range(0, sharps.Length)], new Vector3(0, 0, z), Quaternion.identity);
				z+=7;
			} else break;
		}
	}
}
