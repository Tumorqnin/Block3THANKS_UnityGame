using UnityEngine;

public class LockerChecker : MonoBehaviour
{
    public QRCodeScanner checker;

    void CheckLock()
    {
        if (checker.unlock == true){
        transform.localEulerAngles = new Vector3(0, -90, 0);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         CheckLock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
