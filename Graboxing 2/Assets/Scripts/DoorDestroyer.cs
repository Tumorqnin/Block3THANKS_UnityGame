using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorDestroyer : MonoBehaviour
{   
    
    public QRCodeScanner qrobj;
    
    DestroyerManager destroyerManager;

 

    public void OpenDoor(){
        Destroy(this.gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this);
        
        
    }

    // Update is called once per frame
    void Update()
    {
    //     Scene scene = SceneManager.GetActiveScene();
    //     if (scene.name == "QRCodeReaderScene"){
    //         Destroy(this.gameObject);

    //     }
    //    if (destroyerManager.unlockDoorLevel1 == true){
    //        OpenDoor();
    //     }
    }
    }

 

