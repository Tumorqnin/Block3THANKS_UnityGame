using UnityEngine;

public class DestroyerManager : MonoBehaviour
{
    static public bool unlockDoorLevel1 = false;

    public GameObject doortracker;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this);
        doortracker = GameObject.FindGameObjectWithTag("door1");
    }

    // Update is called once per frame
    void Update()
    {
       if (unlockDoorLevel1 == true){
        Destroy(doortracker);
       }
    }
}
