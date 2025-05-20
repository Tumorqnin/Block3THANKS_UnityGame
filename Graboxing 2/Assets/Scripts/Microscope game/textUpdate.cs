using TMPro;  // Import the TextMesh Pro namespace
using UnityEngine;

public class TextUpdate : MonoBehaviour
{
    // Reference to the TMP_Text component
    public TMP_Text myText;

    // Start is called before the first frame update
    void Start()
    {
       
        myText.text = "Hello world!";
        
    }

    // Method to update the text from another script or event
    public void UpdateTextContent(string newText)
    {}
        //myText.text = newText;
    
    
}