using UnityEngine;
using System.Collections.Generic;

public class StopMovementCollider : MonoBehaviour
{
    private Animator npcAnimator;
    private Collider player;
    public List<GameObject> objectsToSetOff = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject objectToSetOff in objectsToSetOff)
            objectToSetOff.SetActive(false);

        npcAnimator = GameObject.FindGameObjectWithTag("Bloby").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();

    }
    
     void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            npcAnimator.SetTrigger("TrStop");
        }
    }
}
