using UnityEngine;

public class OpenMicroscope : MonoBehaviour
{
    public GameObject uiPanel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Example: Press "E" to interact
        {
            uiPanel.SetActive(true);
            float distance = Vector3.Distance(Camera.main.transform.position, transform.position);
            //if (distance < 3f) // Limit interaction to within 3 units
            {
                //uiPanel.SetActive(true);
            }
        }
    }
        
}
