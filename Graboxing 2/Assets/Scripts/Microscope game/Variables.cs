using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class Variables : MonoBehaviour
{

    public static List<int> lenses = new List<int> { 1, 1, 1, 1, 1, 1 }; //adds the amount of lenses in a list with multiplier 1
    public static List<int> lens_catalogue = new List<int> {25, 4, 2, 5, 20, 10 }; //adds all the individual multipliers if turned on

    public Image targetImage;
    public TMP_Text lensText; //For the text to be added for "... X" multiplier
    public int total_zoom;

    void Start()
    {
        Multiplier_Calculation(); // Calculate initial zoom
    }

    public void Multiplier_Calculation()
    {
        total_zoom = 1; //With 0 lenses de zoom is 1x (aka normal vision)

        for (int x = 0; x < lenses.Count; x++) //Loops over all lenses multiplier for the product of all multipliers
        {
            total_zoom *= lenses[x];
        }

        lensText.text = "The microscope zooms in " + total_zoom + "X"; //Updates text with the new multiplier
    }

    public void CheckZoom()
    {
        if (total_zoom <= 100)
        {
            
        }

    }
}