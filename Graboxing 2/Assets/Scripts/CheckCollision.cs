using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class CheckCollision : MonoBehaviour
{
    GameObject dialogue;
    public Rigidbody player_rigid;

    void Start()
    {
        dialogue = GameObject.FindWithTag("DialogueSystem");
        dialogue.gameObject.SetActive(false);
        player_rigid = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("NPC"))
        {
            EnableRagdoll();
            dialogue.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals("NPC"))
        {
            dialogue.gameObject.SetActive(false);
            DisableRagdoll();
            SceneManager.LoadScene("Assets/Scenes/QRCodeReaderScene.unity");
        }
    }

    // Let the rigidbody take control and detect collisions.
    void EnableRagdoll()
    {
        player_rigid.isKinematic = false;
    }

    // Let animation control the rigidbody and ignore collisions.
    void DisableRagdoll()
    {
        player_rigid.isKinematic = true;
    }
}
