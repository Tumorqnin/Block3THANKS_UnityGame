using UnityEngine;
using System.Collections;
using TMPro;

public class Dialogue_on_click : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    public CanvasGroup panel;
    private bool dialogueFinished = false;

    public void Start()
    {
        
    }

    void Update()
    {
    
    }
    public void Dialogue_Click()
    {
        Debug.Log("I'm clicked");
        textComponent.text = string.Empty;
        panel = GetComponent<CanvasGroup>();
        gameObject.SetActive(true);
        StartDialogue();

    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueFinished = true;
        }
    }
}
