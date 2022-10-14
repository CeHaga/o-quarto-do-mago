using System.Collections;
using UnityEngine;
using TMPro;

public class SubtitleController : MonoBehaviour {
	[SerializeField] private TextMeshProUGUI _textMesh;
	
	public Dialog[] testDialogs;
	
	public IEnumerator CO_SetTextForSeconds(Dialog dialog) {
		_textMesh.enabled = true;
		_textMesh.SetText(dialog.text);
		yield return new WaitForSeconds(dialog.textSpeed.time);
		//_textMesh.enabled = false;
	}
	
	public IEnumerator CO_PlayDialogs(Dialog[] dialogs) {
		foreach (var dialog in dialogs) {
			yield return StartCoroutine(CO_SetTextForSeconds(dialog));
		}
	}
	
	public void StartText(Dialog[] dialogs) {
		StartCoroutine(CO_PlayDialogs(dialogs));
	}
	
	public void DebugDialog() {
		Debug.Log("DebugDialog");
		StartCoroutine(CO_PlayDialogs(testDialogs));
	}
}
