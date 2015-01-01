using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour 
{
	private GameObject _worldCenter;
	
	
	void Start()
	{
		_worldCenter = GameObject.FindGameObjectWithTag("WorldCenter");
	}
	
	void Update () 
	{
		
		gameObject.transform.rotation = _worldCenter.transform.rotation;
	}
}
