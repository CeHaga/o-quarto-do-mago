using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : MonoBehaviour
{
	public static GameState gameState;
	public DialogEvent playDialog;
	
	private void Awake()
	{
		gameState = GameState.Playing;
	}
	
	private void Update()
	{
		if(gameState == GameState.End)
		{
			Debug.Log("Game Over");
			Application.Quit();
		}	
	}
}
