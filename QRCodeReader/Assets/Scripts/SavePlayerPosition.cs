using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePlayerPosition : MonoBehaviour
{
    string nameCurrentScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        nameCurrentScene = SceneManager.GetActiveScene().name;
    }

    void Start()
    {
        if (PlayerPrefs.HasKey (nameCurrentScene + "X") && PlayerPrefs.HasKey (nameCurrentScene + "Y") && PlayerPrefs.HasKey (nameCurrentScene + "Z") ){
            transform.position = new Vector3(PlayerPrefs.GetFloat(nameCurrentScene + "X"), PlayerPrefs.GetFloat(nameCurrentScene + "Y"), PlayerPrefs.GetFloat(nameCurrentScene + "Z"));
        }
    }

    public void SaveLocation() {
        PlayerPrefs.SetFloat (nameCurrentScene + "X", transform.position.x);
        PlayerPrefs.SetFloat (nameCurrentScene + "Y", transform.position.y);
        PlayerPrefs.SetFloat (nameCurrentScene + "Z", transform.position.z);
        
    }
}
