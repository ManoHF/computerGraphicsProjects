using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas canvas1;
    public Canvas canvas2;

    void Start()
    {
        // Desactivar el Canvas al inicio
        canvas1.enabled = false;
        canvas2.enabled = true;
    }

    void Update()
    {
        // Mostrar o ocultar el Canvas al presionar la tecla 'E'
        if (Input.GetKeyDown(KeyCode.E))
        {
            canvas1.enabled = !canvas1.enabled;
            canvas2.enabled = !canvas2.enabled;
        }
    }
}

