using System.Collections;
using UnityEngine;
using TMPro;

public class SubtitleController : MonoBehaviour {
	[SerializeField] private GameObject dialogBoxPanel;
	[SerializeField] private TextMeshProUGUI textMesh;
	
	public Dialog[] testDialogs;
	
	private void Start() 
	{
		dialogBoxPanel.SetActive(false);
	}
	
	private IEnumerator CO_SetTextForSeconds(Dialog dialog) {
		textMesh.enabled = true;
		string text = "";
		foreach (char c in dialog.text) {
			text += c;
			textMesh.text = text;
			yield return new WaitForSeconds(dialog.timeBetweenLetters);
		}
		yield return new WaitForSeconds(0.5f);
		textMesh.enabled = false;
	}
	
	private IEnumerator CO_PlayDialogs(Dialog[] dialogs) {
		dialogBoxPanel.SetActive(true);
		foreach (var dialog in dialogs) {
			yield return StartCoroutine(CO_SetTextForSeconds(dialog));
		}
		dialogBoxPanel.SetActive(false);
	}
	
	public void StartText(Dialog[] dialogs) {
		StartCoroutine(CO_PlayDialogs(dialogs));
	}
	
	public void DebugDialog() {
		Debug.Log("DebugDialog");
		StartCoroutine(CO_PlayDialogs(testDialogs));
	}
}
