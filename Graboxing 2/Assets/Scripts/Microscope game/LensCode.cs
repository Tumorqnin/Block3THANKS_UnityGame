using UnityEngine;

public class LensCode : MonoBehaviour
{
    private int lensNumber;
    private int zoom = 1;
    private bool onOff = false;

    public UIDraggable lens; //To add the lens to for it 
    public RectTransform lensOn1; //Snap point 1
    public RectTransform lensOn2; //Snap point 2
    public RectTransform lensOn3; //Snap point 3

    private RectTransform[] snapPoints;
    private RectTransform lensRect;

    void Start()
    {
        //Extract lens number from name (e.g. "lens_1" to 0)
        string objName = gameObject.name;
        string numberString = objName.Replace("lens_", "");
        if (int.TryParse(numberString, out lensNumber))
        {
            lensNumber -= 1;
            Debug.Log("Lens number is: " + lensNumber);
        }

        zoom = Variables.lens_catalogue[lensNumber]; //Give this object the correct zoom from the Variables list
        lensRect = lens.GetComponent<RectTransform>(); //Able to more easily move the lens in de 2D UI

        snapPoints = new RectTransform[] { lensOn1, lensOn2, lensOn3 }; //Make list of snappoints

        Debug.Log("The snappoints are" + snapPoints);
    }

    void Update()
    {
        CheckDistanceToSnapPoints();
    }

    void CheckDistanceToSnapPoints()
    {
        foreach (var snapPoint in snapPoints)
        {
            float distance = Vector2.Distance(lensRect.anchoredPosition, snapPoint.anchoredPosition);

            if (distance <= 50f)
            {
                if (!onOff)
                {
                    On();
                    onOff = true;
                }
                return;
            }
        }

        // If no snap point is near
        if (onOff)
        {
            Off();
            onOff = false;
        }
    }

    void On()
    {
        Variables.lenses[lensNumber] = zoom; //Indexing to make the lens the actual zoom instead of 1
        Variables vars = FindObjectOfType<Variables>(); //Name the Variables controller so it can be called easily
        vars.Multiplier_Calculation(); //Calling the new multiplier calculation
        Debug.Log("Lens turned ON at zoom " + zoom);
    }

    void Off()
    {
        Variables.lenses[lensNumber] = 1;
        Variables vars = FindObjectOfType<Variables>();
        vars.Multiplier_Calculation();
        Debug.Log("Lens turned OFF");
    }
}