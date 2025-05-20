using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class CheckCollision : MonoBehaviour
{
    GameObject dialogue;
    GameObject gameStarter;
    public Rigidbody player_rigid;

    void Start()
    {
        dialogue = GameObject.FindWithTag("DialogueSystem");
        gameStarter = GameObject.FindWithTag("Game");
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

        if (collision.gameObject.tag.Equals("GameStarter"))
        {
            PlayerMove.moveSpeed = 0;
            gameStarter.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals("NPC"))
        {
            dialogue.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag.Equals("GameStarter"))
        {
            gameStarter.gameObject.SetActive(false);
        }
    }
}
