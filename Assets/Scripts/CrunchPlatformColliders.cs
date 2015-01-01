using UnityEngine;
using System.Collections;

public class CrunchPlatformColliders : MonoBehaviour 
{
	void Start () 
	{
		setPlayerPos();
		crunchCollidersToPlayer();
	}
	
	void Update()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Ray ray = new Ray(player.transform.position, Vector3.down * 100);
		Debug.DrawRay(ray.origin, ray.direction);
	}
	
	public void crunchCollidersToPlayer()
	{	
		/*Transform playerTrans = getPlayer().transform;
		GameObject[] allPlatforms = GameObject.FindGameObjectsWithTag("Platform");

		int numPlatforms = allPlatforms.Length;
		for (int i = 0; i < numPlatforms; i++) {
			GameObject platform = allPlatforms[i];
			BoxCollider collider = platform.GetComponentInChildren<BoxCollider>();
			collider.center = Vector3.zero;
			
			//convert pos vec into world space
			Vector3 colliderPos = collider.transform.TransformPoint(collider.center);
			
			Vector3 playerPos = playerTrans.position;
			Vector3 newColliderPos;
			
			//move platform collider depending on what side the camera is facing 
			Vector3 normalCam = Camera.main.transform.position.normalized;
			if (Mathf.Abs(Mathf.Round(normalCam.x)) == 1.0f)
				newColliderPos = new Vector3(playerPos.x, colliderPos.y, colliderPos.z);
			else
				newColliderPos = new Vector3(colliderPos.x, colliderPos.y, playerPos.z);
			
			//converts back into local space
			newColliderPos = collider.transform.InverseTransformPoint(newColliderPos);
			
			collider.center = newColliderPos;
		}*/
	}
	
	public void setPlayerPos() 
	{
		GameObject player = getPlayer();
		Ray ray = new Ray(player.transform.position, Vector3.down);
		RaycastHit hit = new RaycastHit();
		if (Physics.Raycast(ray, out hit, 100.0f))
		{
			GameObject platform = hit.collider.gameObject;
			Vector3 colliderPos = ((BoxCollider)(hit.collider)).center;
			Vector3 playerPos = platform.transform.InverseTransformPoint(player.transform.position);
			Vector3 newPos = new Vector3(playerPos.x - colliderPos.x, playerPos.y, playerPos.z - colliderPos.z);
			newPos = platform.transform.TransformPoint(newPos);
			
			player.transform.position = newPos;
		}
	}
	
	private GameObject getPlayer()
	{
		return GameObject.FindGameObjectWithTag("Player");
	}
}
