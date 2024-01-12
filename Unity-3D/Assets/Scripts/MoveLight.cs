using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveLight : MonoBehaviour
{
    public Transform targetLight;
    public TMP_InputField xInputField;
    public TMP_InputField yInputField;
    public TMP_InputField zInputField;
    public Vector3 initialPos;

    void Start()
    {
        initialPos = targetLight.localPosition;
        Debug.Log("Initial Position: " + initialPos);
    }

    public void MoveLightByInputFields()
    {
        float x = ParseInputField(xInputField.text);
        float y = ParseInputField(yInputField.text);
        float z = ParseInputField(zInputField.text);

        MoveLightToPosition(x, y, z);
    }

    float ParseInputField(string input)
    {
        float result;
        return float.TryParse(input, out result) ? result : 0f;
    }

    void MoveLightToPosition(float x, float y, float z)
    {
        if (targetLight != null)
        {
            Vector3 newPos = new Vector3(x, y, z);
            targetLight.localPosition = newPos;

            Debug.Log("New pos! " + newPos);
        }
        else
        {
            Debug.LogWarning("Light reference is not set!");
        }
    }
}
