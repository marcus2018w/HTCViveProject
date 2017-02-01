using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SkyFall : MonoBehaviour {
	 GameObject[,] skyArray;
	GameObject camera;
	Rigidbody rig;
	System.Random rand;
	float timer = 0f;
	// Use this for initialization
	void Start()
	{
		camera = GameObject.Find("CameraRig") ;
		transform.localPosition = new Vector3 (6f,9f,6f);
		 rig = camera.GetComponent<Rigidbody>();
		rig.useGravity = false;
		rig.isKinematic = true;


		skyArray = new GameObject[7, 7];
		//GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
		for (int i = 0; i < 7; i++)
		{
			for (int j = 0; j < 7; j++)
			{
				skyArray[i, j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
				skyArray[i, j].transform.localPosition = new Vector3(i,9f,j);
			}

		}
	}

	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;
		if(timer >15f){
		rand = new System.Random();
		int block = rand.Next(0, 6);
		int block1 = rand.Next(0, 6);
		deleteBlock(block,block1);


		}

	
	}

	private void deleteBlock(int i, int j){
		if (skyArray[i, j] == null)
		{
			
			i= rand.Next(0, 6);
			j = rand.Next(0, 6);

		}

			
			Destroy(skyArray[i, j]);
			if ((camera.transform.localPosition.x <= 6f - .5f) 
			     &&
			    (camera.transform.localPosition.z <= 6f + 0.5f)) {
				rig.useGravity = true;
			rig.isKinematic = false;
			Debug.Log (camera.transform.localPosition.x+","+ camera.transform.localPosition.y);

			} 
		else if ((camera.transform.localPosition.x >= 6f - .5f) ||(camera.transform.localPosition.x <= 6f - .5f)
            &&
			(camera.transform.localPosition.z >= 6f + 0.5f) ||(camera.transform.localPosition.x <= 6f +.5f) )
			{
			rig.useGravity = false;;
			rig.isKinematic = true;
			}


	
	
			



	}
}