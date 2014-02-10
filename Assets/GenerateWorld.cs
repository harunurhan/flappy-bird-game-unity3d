using UnityEngine;
using System.Collections;

public class GenerateWorld : MonoBehaviour {
	
	public Transform block;
	public Transform player;
	private float objectSpawnedTo = 5.0f;
	public static float distanceBetweenObjects = 9.5f;
	private float nextCheck = 0.0f;
	private ArrayList objects = new ArrayList();
	void Start () {
		maintenance(0.0f);
	}
	
	
	void Update () {
		float playerX = player.position.x;
		if(playerX > nextCheck)
		{
			maintenance(playerX);
		}
	}
	
	private void maintenance(float playerX)
	{
		nextCheck = playerX + 30;
		for (int i = objects.Count-1; i >= 0; i--) 
		{
			Transform blck = (Transform)objects[i];
			if(blck.position.x < (transform.position.x - 30))
			{
				Destroy(blck.gameObject);
				objects.RemoveAt(i);
			}
		}
		spawnObjects(5);
	}
	
	private void spawnObjects(int howMany)
	{
		float spawnX = objectSpawnedTo;
		for(int i = 0; i<howMany; i++)
		{
			Vector3 pos = new Vector3(spawnX, 6.0f, 0);
			float firstRandom = Random.Range(1,8.6f);
			Transform blck = (Transform)Instantiate(block, pos, Quaternion.identity);
			blck.localScale+=new Vector3(0,firstRandom*2,0);
			objects.Add(blck);
			pos = new Vector3(spawnX, -6.0f, 0);
			blck = (Transform)Instantiate(block, pos, Quaternion.identity);
			blck.localScale +=new Vector3(0,(8.6f-firstRandom)*2,0);
			objects.Add(blck);
			spawnX = spawnX + distanceBetweenObjects;
		}
		objectSpawnedTo = spawnX;
	}
	
}
