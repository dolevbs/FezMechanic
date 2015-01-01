using UnityEngine;
using System.Collections;

public class CameraRotator : MonoBehaviour 
{
	public float rotateTime = 1.0f;
	
	private bool _isTweening = false;
	private CrunchPlatformColliders _cruncher;
	private DisablePlayer _disablePlayer;
	
	void Start () 
	{
		_cruncher = GetComponentInChildren<CrunchPlatformColliders>();
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		_disablePlayer = player.GetComponentInChildren<DisablePlayer>();
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Z))
		{
			rotateTween(90);
		}
		
		if (Input.GetKeyDown(KeyCode.X))
		{
			rotateTween(-90);
		}
	}
	
	private void rotateTween(float amount) 
	{
		if (_isTweening == false) 
		{
			_isTweening = true;
			_cruncher.setPlayerPos();
			_disablePlayer.disable();
			Vector3 rot = new Vector3(0,amount, 0);
			iTween.RotateAdd(gameObject, iTween.Hash(iT.RotateAdd.time, rotateTime, iT.RotateAdd.amount, rot, iT.RotateAdd.easetype, iTween.EaseType.easeInOutSine, iT.RotateAdd.oncomplete, "onColorTweenComplete"));
		}
	}
	
	private void onColorTweenComplete()
	{
		_isTweening = false;
		_disablePlayer.enable();
		_cruncher = GetComponentInChildren<CrunchPlatformColliders>();
		_cruncher.crunchCollidersToPlayer();
	}
}
