using System.Collections;
using UnityEngine;
using TMPro;

public class SubtitleController : MonoBehaviour
{
	[SerializeField] private GameObject dialogBox;
	[SerializeField] private BoxCollider2D dialogCollider;
	[SerializeField] private TextMeshProUGUI dialogTextMesh;
	[SerializeField] private TextMeshProUGUI nameTextMesh;
	
	public Dialog[] testDialogs;
	
	public Dialog[] startingDialogs;
	
	private bool waitingDialog;
	private bool skipDialog;
	private Dialog[] currentDialogs;
	private int currentDialogIndex;
	
	private void Start() {
		dialogCollider.enabled = false;
		dialogBox.SetActive(false);
		waitingDialog = false;
		skipDialog = false;
		currentDialogs = null;
		currentDialogIndex = 0;
		
		StartText(startingDialogs);
	}

	public void OnMouseDown()
	{
		if(GameStateManager.gameState == GameState.Dialog)
		{
			skipDialog = true;
			if(waitingDialog)
			{
				StartCoroutine(CO_ContinueDialog());
			}
		}
	}
	
	private IEnumerator CO_ContinueDialog()
	{
		if(currentDialogIndex == currentDialogs.Length)
		{
			EndDialog();
			yield break;
		}
		
		ResetDialogBox();
		yield return StartCoroutine(CO_SetTextForSeconds(currentDialogs[currentDialogIndex]));
		
		currentDialogIndex++;
		waitingDialog = true;
	}
	
	public void EndDialog()
	{
		dialogBox.SetActive(false);
		dialogCollider.enabled = false;
		GameStateManager.gameState = GameState.Playing;
	}
	
	private IEnumerator CO_SetTextForSeconds(Dialog dialog)
	{
		string text = "";
		nameTextMesh.text = dialog.character.name;
		foreach (char c in dialog.text)
		{
			if(skipDialog)
			{
				dialogTextMesh.text = dialog.text;
				yield break;
			}
			text += c;
			dialogTextMesh.text = text;
			yield return new WaitForSeconds(dialog.timeBetweenLetters);
		}
	}
	
	public void StartText(Dialog[] dialogs)
	{
		GameStateManager.gameState = GameState.Dialog;
		
		currentDialogs = dialogs;
		currentDialogIndex = 0;
		dialogBox.SetActive(true);
		dialogCollider.enabled = true;
		
		StartCoroutine(CO_ContinueDialog());
	}
	
	private void ResetDialogBox()
	{
		waitingDialog = false;
		skipDialog = false;
		dialogTextMesh.text = "";
		nameTextMesh.text = "";
	}
	
	public void DebugDialog()
	{
		Debug.Log("DebugDialog");
		StartText(testDialogs);
	}
	
	public void StartingDialog()
	{
		StartText(startingDialogs);
	}
	
	public void BreakDialog()
	{
		skipDialog = true;
		EndDialog();
	}
}
