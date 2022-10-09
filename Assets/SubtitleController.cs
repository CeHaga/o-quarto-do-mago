using System.Collections;
using UnityEngine;
using TMPro;

public class SubtitleController : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _textMesh;

    public IEnumerator SetTextForSeconds(string text, float seconds) {
        _textMesh.enabled = true;
        _textMesh.SetText(text);
        yield return new WaitForSeconds(seconds);
        _textMesh.enabled = false;
    }
    
    void Start() {
        StartCoroutine(SetTextForSeconds("Lorem Ipsum is for dummies", 3f));
    }
}
