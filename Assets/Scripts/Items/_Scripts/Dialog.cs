using UnityEngine;

[System.Serializable]
public class Dialog {
	public Character character;
	[TextArea(2,5)] public string text;
	public Speed textSpeed;
	
	public Dialog(string text, Speed textSpeed) {
		this.text = text;
		this.textSpeed = textSpeed;
	}
	
	public float timeBetweenLetters {
		get {
			return textSpeed.time;
		}
	}
}

