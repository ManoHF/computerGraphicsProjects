using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{
    private Vector3 pos;

    [SerializeField] private List<GameObject> listaFiguras = new List<GameObject>();
    [SerializeField] private List<GameObject> listaFigurasInst = new List<GameObject>();
    private GameObject figurasHIER;

    private int sigFig = 0;
    private int capa = 0;

    private float[] coords = {
        //  x       z       rotx    roty      rotz
        0.31f, -18.25f,     90.0f,  13.056f, 0.0f,   //fig1
        3.78f, -18.25f,     90.0f,  22.806f, 0.0f,   //fig2
        //---- capa 2 ----
        0.04f, -18.34f,     0.0f,   0.0f,   0.0f,    //fig21
        0.6f,  -18.34f,     0.0f,   0.0f,   0.0f,    //fig22
        3.797f, -18.77f,    0.0f,   0.0f,   0.0f,    //fig3
        //--- capa 3 -----
        0.04f,  -18.34f,     0.0f,   0.0f,   0.0f,     //fig24
        0.6f,   -18.34f,     0.0f,   0.0f,   0.0f,     //fig23
        3.797f, -18.77f,     0.0f,   0.0f,   0.0f,     //fig4
        2.045f, -18.25f,     62.87f,  76.7f, -98.343f,   //fig14
        //--- capa 4 ----
        0.04f,  -18.34f,     0.0f,   0.0f,   0.0f,     //fig25
        0.6f,   -18.34f,     0.0f,   0.0f,   0.0f,     //fig26
        2.045f, -18.25f,     90.0f,  13.056f, 0.0f,   //fig15
        3.797f, -18.77f,     0.0f,   0.0f,   0.0f,     //fig5
        //--- capa 5 ----
        0.28f,  -18.34f,     0.0f,   0.0f,   0.0f,     //fig27
        2.045f, -18.25f,     79.0f,  -16.3f, -201.0f,   //fig16
        3.797f, -18.77f,     0.0f,   0.0f,   0.0f,     //fig6
        //--- capa 6 ---
        2.045f, -18.25f,     90.0f,  70.0f, 0.0f,    //fig17
        3.797f, -18.77f,     0.0f,   0.0f,   0.0f,     //fig7
        //--- capa 7 ---
        2.045f, -18.25f,     0.0f,  0.0f, 0.0f,    //fig18
        3.797f, -18.77f,     0.0f,   0.0f,   0.0f,     //fig8
        //--- capa 8 ---
        2.045f, -18.25f,     13.3f,  -90.0f, 0.0f,    //fig19
        3.797f, -18.77f,     0.0f,   0.0f,   0.0f,     //fig9
        //--- capa 9 ---
        2.045f, -18.25f,     13.53f,  90.0f, 0.0f,    //fig19
        3.797f, -18.77f,     0.0f,   0.0f,   0.0f,     //fig10
        //--- capa 10 ---
        3.797f, -18.77f,     -90.0f,   0.0f,   0.0f,     //fig11
        //--- capa 11 ---
        3.797f, -18.77f,     0.0f,   0.0f,   0.0f,     //fig12
        //--- capa 12 ---
        3.797f, -18.77f,     0.0f,   0.0f,   0.0f,    //fig13
        0.28f,  -18.34f,     0.0f,   0.0f,   0.0f     //fig28
    };

    public List<GameObject> ListaFiguras
    {
        get { return listaFiguras; }
        set { listaFiguras = value; }
    }

    public List<GameObject> ListaFigurasInst
    {
        get { return listaFigurasInst; }
        set { listaFigurasInst = value; }
    }

    // Start is called before the first frame update
    void Start()
    {

        pos = transform.position;
        figurasHIER = new GameObject();
        figurasHIER.name = "Figuras";

    }

    // Update is called once per frame
    void Update()
    {
        CrearFigura();
        VerificarAltura();
    }

    void VerificarAltura()
    {
        foreach (GameObject figura in listaFigurasInst)
        {
            if (figura.transform.position.y < -10)
                figura.transform.position = pos + new Vector3(0.5f, 5, 0);
        }
    }

    void CrearFigura()
    {
        if (Input.GetButtonDown("Jump") && sigFig < 28)
        {
            Debug.Log("siFig: " + sigFig + " capa: " + capa);
            GameObject figInst = Instantiate(listaFiguras[sigFig], new Vector3(coords[capa], 10, coords[capa + 1]),
                Quaternion.Euler(coords[capa + 2], coords[capa + 3], coords[capa + 4]));

            capa += 5;
            sigFig++;
            // GameObject fig2Inst = Instantiate(fig2, new Vector3(3.78f, Random.Range(6.27f, 10.0f), -18.58f), Quaternion.Euler(85.47f, 22.806f, -162.6f));

            listaFigurasInst.Add(figInst.gameObject);
            figInst.transform.parent = figurasHIER.gameObject.transform;
        }
    }

    private void OnMouseDown()
    {
        ExplotarFiguras();
        Debug.Log("Picaste boton");
    }

    public void ExplotarFiguras()
    {
        foreach (GameObject figura in listaFigurasInst)
        {
            Debug.Log("Hola");
            Figuras fig = figura.GetComponent<Figuras>();
            fig.Explotar(pos);
        }

    }
}
