using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class CheckCollision : MonoBehaviour
{
    [SerializeField] private GameObject objectToCollideWith;
    public GameObject ObjectToCollideWith => objectToCollideWith;
    [SerializeField] private GameObject objectToSetOff;
    public GameObject ObjectToSetOff => objectToSetOff;

    void Start()
    {
        objectToSetOff = GameObject.FindWithTag(ObjectToSetOff.tag);
        objectToSetOff.SetActive(false);
    }

    private void Update()
    {
        if(objectToSetOff.gameObject.activeInHierarchy == false)
        {
            CharacterMovement.moveSpeed = 2f;
        }
        else
        {
            CharacterMovement.moveSpeed = 0f;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals(ObjectToCollideWith.tag))
        {
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