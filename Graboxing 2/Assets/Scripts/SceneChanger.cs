using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
   static public GameObject Player;
   static public string m_SceneToLoad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static void Start(string sceneToLoad)
    {
        m_SceneToLoad = sceneToLoad;
    }

    // Update is called once per frame
    static void Update()
    {
            Player.GetComponent<SavePlayerPosition>().SaveLocation();
            SceneManager.LoadScene(m_SceneToLoad);
    }
}