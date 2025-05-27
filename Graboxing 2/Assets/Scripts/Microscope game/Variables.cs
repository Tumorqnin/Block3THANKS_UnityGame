using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Variables : MonoBehaviour
{
    public static List<int> lenses = new List<int> { 1, 1, 1, 1, 1, 1 };
    public static List<int> lens_catalogue = new List<int> { 25, 4, 2, 5, 20, 10 };

    public Image targetImage;
    public TMP_Text lensText;
    public int total_zoom;

    private bool zoomReached = false;

    void Update()
    {
        Multiplier_Calculation();

        if (!zoomReached && total_zoom == 200)
        {
            zoomReached = true;
            StartCoroutine(WaitBeforeSceneChange(1f));
        }
    }

    public void Multiplier_Calculation()
    {
        total_zoom = 1;
        for (int x = 0; x < lenses.Count; x++)
        {
            total_zoom *= lenses[x];
        }

        lensText.text = "The microscope zooms in " + total_zoom + "X";
    }

    IEnumerator WaitBeforeSceneChange(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Double check if the zoom is still 200 after the delay
        if (total_zoom == 200)
        {
            SceneManager.LoadScene("MainRoom_2");
        }
        else
        {
            zoomReached = false; // Reset if condition is no longer valid
        }
    }
}
