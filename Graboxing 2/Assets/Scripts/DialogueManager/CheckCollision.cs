using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class CheckCollision : MonoBehaviour
{
    [SerializeField] private GameObject objectToCollideWith;
    public GameObject ObjectToCollideWith => objectToCollideWith;
    [SerializeField] private GameObject objectToSetOff;
    public GameObject ObjectToSetOff => objectToSetOff;
    public Rigidbody player_rigid;

    void Start()
    {
        objectToSetOff = GameObject.FindWithTag(ObjectToSetOff.tag);
        objectToSetOff.SetActive(false);
        player_rigid = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals(ObjectToCollideWith.tag))
        {
            PlayerMove.moveSpeed = 0;
            objectToSetOff.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals(ObjectToCollideWith.tag))
        {
            objectToSetOff.gameObject.SetActive(false);
        }
    }
}