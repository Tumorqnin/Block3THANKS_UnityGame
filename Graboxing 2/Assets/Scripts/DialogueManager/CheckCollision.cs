using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CheckCollision : MonoBehaviour
{
    private List<GameObject> colliders = new List<GameObject>();

    [SerializeField]
    private Transform npcTransform;

    [SerializeField]
    private Transform playerTransform;

    public float rotateSpeed = 1f;

    bool focusNPC = false;


    private void Update()
    {
        bool stopMove = false;
        foreach (GameObject collider in colliders)
        {
            if (collider.activeSelf)
            {
                stopMove = true;
            }
        }
        CharacterMovement.moveSpeed = stopMove ? 0f : 2f;

        float singleStep = rotateSpeed * Time.deltaTime;

        if (focusNPC == true)
        {
            if (Physics.Raycast(npcTransform.position, npcTransform.forward, out RaycastHit hitInfo, 20))
            {

                Debug.Log("Acertou");
                Vector3 targetDirection = npcTransform.position - playerTransform.position;
                targetDirection.y = 0;
                Vector3 viewDirection = Vector3.RotateTowards(playerTransform.forward, targetDirection, singleStep, 0f);
                playerTransform.rotation = Quaternion.LookRotation(viewDirection);

            }
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        StopMovementCollider stopMovementCollider = collision.GetComponent<StopMovementCollider>();
        if (stopMovementCollider)
        {
            focusNPC = true;

            foreach (GameObject objectToSetOff in stopMovementCollider.objectsToSetOff)
            {
                colliders.Add(objectToSetOff);
                objectToSetOff.SetActive(true);
            }
        }

        
    }

    void OnTriggerExit(Collider collision)
    {
        focusNPC = false;
    }
}