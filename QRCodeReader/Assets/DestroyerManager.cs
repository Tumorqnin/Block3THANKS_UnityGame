using UnityEngine;

public class DestroyerManager : MonoBehaviour
{
    public bool unlockDoorLevel1 = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
