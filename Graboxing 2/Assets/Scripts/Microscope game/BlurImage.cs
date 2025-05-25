using UnityEngine;

public class CloseUI: MonoBehaviour
{

    public GameObject ClosePanel;

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
        ClosePanel.SetActive(false); //turns the panel (we put in the inspector) off
    }
}
