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
           // PlayerMove.moveSpeed = 0;
            dialogue.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals("NPC"))
        {
            dialogue.gameObject.SetActive(false);
        }
    }
}
