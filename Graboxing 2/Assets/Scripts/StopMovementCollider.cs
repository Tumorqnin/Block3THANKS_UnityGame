using UnityEngine;
using System.Collections.Generic;

public class StopMovementCollider : MonoBehaviour
{
    public List<GameObject> objectsToSetOff = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(GameObject objectToSetOff in objectsToSetOff)
        objectToSetOff.SetActive(false);
    }
}
