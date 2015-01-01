using UnityEngine;
using System.Collections;

public class GotoNextScene : MonoBehaviour 
{
	private int _currentLevelIndex;
	private int _levelCount;
	
	// Use this for initialization
	void Start () 
	{
	 	_currentLevelIndex = Application.loadedLevel;
		_levelCount = Application.levelCount;
	}
	
	void Update()
	{
		if (Input.GetButtonDown("NextLevel"))
		{
			next();	
		}
	}
	
	public void next()
	{
		if (_currentLevelIndex < _levelCount - 1)
			_currentLevelIndex++;
		else
			_currentLevelIndex = 0;	
		Application.LoadLevel(_currentLevelIndex);
	}
	
	public void previous()
	{
		if (_currentLevelIndex - 1 > -1 )
			_currentLevelIndex--;
		else
			_currentLevelIndex = _levelCount - 1;	
		Application.LoadLevel(_currentLevelIndex);
	}
}
