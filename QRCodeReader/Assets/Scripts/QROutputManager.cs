using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QROutputManager : MonoBehaviour
{
   public QRCodeScanner manager;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
       // qrCodeScanner = GameObject.FindGameObjectWithTag("QrCodeReader").GetComponent<QRCodeScanner>();
    }

    // Update is called once per frame
    void Update()
    {
       if (manager != null)
        {
            string outputQRCode = manager.scannedText;
            if (outputQRCode == "unlockpuzzle1")
            {
                GameObject.FindGameObjectWithTag("door").transform.localEulerAngles = new Vector3(0, 90, 0);
                SceneManager.LoadScene("MainRoom");
            }
        }
    }
}
