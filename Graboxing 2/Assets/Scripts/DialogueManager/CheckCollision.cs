using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CheckCollision : MonoBehaviour
{
    private List<GameObject> colliders = new List<GameObject>();

    private void Update()
    {
        bool stopMove = false;
        foreach(GameObject collider in colliders)
        {
            if (collider.activeSelf)
            {
                stopMove = true;
            }
        }
            CharacterMovement.moveSpeed = stopMove ? 0f : 2f;
    }

    void OnTriggerEnter(Collider collision)
    {
        StopMovementCollider stopMovementCollider = collision.GetComponent<StopMovementCollider>();
        if (stopMovementCollider)
        {
            foreach(GameObject objectToSetOff in stopMovementCollider.objectsToSetOff)
            {
                colliders.Add(objectToSetOff);
                objectToSetOff.SetActive(true);
            }
        }
    }
}