using UnityEngine;

public class ClosePanel: MonoBehaviour
{

    public GameObject CloseScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Close()
    {
        Debug.Log("I'm closinggggg");
        CloseScreen.SetActive(false); //turns the panel (we put in the inspector) off
    }
}
