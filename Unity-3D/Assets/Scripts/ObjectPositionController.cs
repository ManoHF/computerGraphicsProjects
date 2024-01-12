using UnityEngine;
using TMPro;

public class ObjectPositionController : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject objectToMove;
    public CoordinateType coordinateToShow = CoordinateType.X;

    public enum CoordinateType
    {
        X,
        Y,
        Z
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set the default text of the InputField to the specified coordinate of the object
        UpdateInputFieldText();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the InputField is not null
        if (inputField != null)
        {
            // Parse the text to a float (assuming it represents a coordinate value)
            if (float.TryParse(inputField.text, out float newPosition))
            {
                // Set the new position of the object based on the specified coordinate
                Vector3 newPositionVector = objectToMove.transform.localPosition;

                switch (coordinateToShow)
                {
                    case CoordinateType.X:
                        newPositionVector.x = newPosition;
                        break;
                    case CoordinateType.Y:
                        newPositionVector.y = newPosition;
                        break;
                    case CoordinateType.Z:
                        newPositionVector.z = newPosition;
                        break;
                }

                objectToMove.transform.localPosition = newPositionVector;
            }
            else
            {
                Debug.LogError("Invalid input. Please enter a valid number.");
            }
        }

        // Update the text of the InputField with the specified coordinate of the object
        UpdateInputFieldText();
    }

    // Function to update the text of the InputField with the specified coordinate of the object
    void UpdateInputFieldText()
    {
        if (inputField != null && objectToMove != null)
        {
            float coordinateValue = 0;

            switch (coordinateToShow)
            {
                case CoordinateType.X:
                    coordinateValue = objectToMove.transform.localPosition.x;
                    break;
                case CoordinateType.Y:
                    coordinateValue = objectToMove.transform.localPosition.y;
                    break;
                case CoordinateType.Z:
                    coordinateValue = objectToMove.transform.localPosition.z;
                    break;
            }

            inputField.text = coordinateValue.ToString();
        }
    }
}

