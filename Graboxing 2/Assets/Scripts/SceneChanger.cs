using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
   public GameObject Player;
   public string sceneToLoad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Player.GetComponent<SavePlayerPosition>().SaveLocation();
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
