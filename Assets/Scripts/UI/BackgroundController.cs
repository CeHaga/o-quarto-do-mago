using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class BackgroundController : MonoBehaviour
{
	public float movingTime = 1f;
	public float backgroundX;
	public float backgroundXPeek;
	public Background[] backgrounds;
	[Header("Dialogs")]
	public DialogEvent playDialog;

	private int actualBackground; 
	private bool isMoving;

	private void Start()
	{
		actualBackground = 0;
		isMoving = false;
	}
	
	// Access element in array as a circular list
	private Background GetBackground(int index)
	{
		return backgrounds[(index + backgrounds.Length) % backgrounds.Length];
	}
	
	// Set background in edge position and return original position
	private Vector3 SetBackgroundEdge(int index, int offset, float x)
	{
		Transform background = GetBackground(index + offset).background.transform;
		Vector3 position = background.position;
		background.position = new Vector3(x * offset, 0, 0);
		return position;
	}
	
	// Set background in new position
	private void SetBackgroundPosition(int index, Vector3 position)
	{
		Transform background = GetBackground(index).background.transform;
		background.position = position;
	}
	
	// Move backgrounds using DOTween
	private IEnumerator MoveBackgrounds(int actual, int direction, float distance, Background nextBackground, int rangeStart = -1, int rangeEnd = 1, float time = 1)
	{
		int newBackgroundIndex = (direction > 0) ? rangeStart - 1 : rangeEnd + 1;
		int oldBackgroundIndex = (direction > 0) ? rangeEnd : rangeStart;
		
		int start = (direction > 0) ? newBackgroundIndex : oldBackgroundIndex;
		int end = (direction > 0) ? oldBackgroundIndex : newBackgroundIndex;
		
		Vector3 oldPosition = SetBackgroundEdge(actual, newBackgroundIndex, backgroundX);

		for (int i = start; i <= end; i++)
		{
			Transform background = GetBackground(actual + i).background.transform;
			float x = background.position.x;
			background.DOMoveX(x + distance * direction, time);
		}
		
		yield return new WaitForSeconds(time);
		SetBackgroundPosition(actual + oldBackgroundIndex, oldPosition);
		
		if(!nextBackground.cutscenePlayed)
		{
			nextBackground.cutscenePlayed = true;
			playDialog.Invoke(nextBackground.cutsceneDialogs, nextBackground.gameState);
		}
		isMoving = false;
	}
	
	// Move backgrounds in case of not available
	private IEnumerator MoveBackgroundsNotAvailable(int actual, int direction, float distance, Background unavailableBackground, int rangeStart = -1, int rangeEnd = 1, float time = 1)
	{
		int start = rangeStart;
		int end = rangeEnd;
		
		playDialog.Invoke(unavailableBackground.unavailableDialogs, null);
		
		for (int i = start; i <= end; i++)
		{
			Transform background = GetBackground(actual + i).background.transform;
			float x = background.position.x;
			background.DOMoveX(x + distance * direction, time);
		}
		
		yield return new WaitForSeconds(time);
		
		for (int i = start; i <= end; i++)
		{
			Transform background = GetBackground(actual + i).background.transform;
			float x = background.position.x;
			background.DOMoveX(x + distance * -direction, time);
		}
		
		yield return new WaitForSeconds(time);
		
		isMoving = false;
	}
 
	public void MoveLeft()
	{
		if (isMoving) return;
		isMoving = true;	
		
		int nextBackgroundIndex = actualBackground - 1;
		Background nextBackground = GetBackground(nextBackgroundIndex);
		
		if (nextBackground.IsAvailable())
		{
			StartCoroutine(MoveBackgrounds(actualBackground, 1, backgroundX, nextBackground));
			actualBackground = nextBackgroundIndex;
		}
		else
		{
			StartCoroutine(MoveBackgroundsNotAvailable(actualBackground, 1, backgroundXPeek, nextBackground));
		}
	}

	public void MoveRight()
	{
		if (isMoving) return;
		isMoving = true;	
		
		int nextBackgroundIndex = actualBackground + 1;
		Background nextBackground = GetBackground(nextBackgroundIndex);
		
		if (nextBackground.IsAvailable())
		{
			StartCoroutine(MoveBackgrounds(actualBackground, -1, backgroundX, nextBackground));
			actualBackground = nextBackgroundIndex;
		}
		else
		{
			StartCoroutine(MoveBackgroundsNotAvailable(actualBackground, -1, backgroundXPeek, nextBackground));
		}
	}
}
