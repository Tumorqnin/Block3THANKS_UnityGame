using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class SnapManager : MonoBehaviour
{
    public List<DraggableJoint> allDraggables;
    public List<SnapControllerJoint> allSnapPoints;
    private bool sceneLoaded = false;

    public void CheckConditions()
    {
        if (sceneLoaded) return;

        bool allDraggablesSnapped = true;
        foreach (var draggable in allDraggables)
        {
            if (!draggable.isSnapped)
            {
                allDraggablesSnapped = false;
                break;
            }
        }

        int usedSnapPoints = 0;
        foreach (var snapPoint in allSnapPoints)
        {
            if (snapPoint.SnappedCount >= 2)
                usedSnapPoints++;
        }

        if (allDraggablesSnapped || usedSnapPoints >= 5)
        {
            sceneLoaded = true;
            StartCoroutine(LoadSceneAfterDelay("MainRoom", 1f));
        }
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
