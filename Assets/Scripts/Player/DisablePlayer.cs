using UnityEngine;
using System.Collections;

public class DisablePlayer : MonoBehaviour 
{
	private CharacterMotor _motor;
	
	void Start () 
	{
		_motor = GetComponentInChildren<CharacterMotor>();
	}
	
	public void disable()
	{
		_motor.enabled = false;
	}
	
	public void enable()
	{
		_motor.enabled = true;
	}
}
