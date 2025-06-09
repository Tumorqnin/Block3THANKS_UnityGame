using UnityEngine;

public class Reset_game : MonoBehaviour
{

     public GameObject canvasObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        canvasObject.SetActive(false);
        Debug.Log("The canva is turned off");
        canvasObject.SetActive(true);
        Debug.Log("The canva is turned on");
    }
}
