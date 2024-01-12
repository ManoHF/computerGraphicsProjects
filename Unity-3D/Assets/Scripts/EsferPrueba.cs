using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferPrueba : MonoBehaviour
{

    private Vector3 pos;
    //[SerializeField] private GameObject figura1;
    // [SerializeField] private GameObject figura2;
    [SerializeField] private List<GameObject> listaFiguras1 = new List<GameObject>();
    [SerializeField] private List<GameObject> listaFiguras = new List<GameObject>();
    [SerializeField] private GameObject pared;
    private GameObject figurasHIER;


    // Start is called before the first frame update
    private float[] coords = {
        //  x       z       rotx    roty      rotz
        0.31f, -18.25f,     90.0f,  13.056f, 0.0f,   //fig1
        3.78f, -18.25f,     90.0f,  22.806f, 0.0f,  //fig2
        //--- capa 2 ---
        0.04f, -18.25f,     0.0f,   0.0f,   0.0f,    //fig21
        0.6f,  -18.25f,     0.0f,   0.0f,   0.0f,    //fig22
        3.797f, -18.25f,    0.0f,   0.0f,   0.0f,    //fig3
        //--- capa 3 -----
        0.04f, -18.25f,     -90.0f,   0.0f,   0.0f,     //fig24
        0.6f,  -18.25f,     -90.0f,   0.0f,   0.0f,      //fig23
        3.797f, -17.95f,     -86.594f,   -2.166f, 92.193f,     //fig4
        1.735f, -18.25f,     62.87f,  76.7f, -98.343f,   //fig14
        //--- capa 4 ----
        0.04f, -18.25f,     90.0f,   0.0f,   0.0f,     //fig26
        0.6f,  -18.25f,     90.0f,   0.0f,   0.0f,      //fig25
        1.6558f, -18.25f,     94.0f,  -148.88f, -161.7f,   //fig15
        3.797f, -18.25f,     0.0f,   0.0f,   0.0f,     //fig5
        //--- capa 5 ----
        0.28f,  -18.34f,     0.0f,   0.0f,   0.0f,     //fig27
        1.937f, -18.25f,     65.178f,  -75.89f, -264.08f,   //fig16
        3.797f, -18.25f,     0.0f,   0.0f,   0.0f,     //fig6
        //--- capa 6 ---
        1.867f, -18.25f,     94.0f,  63.08f, -7.24f,    //fig17
        3.797f, -18.25f,     0.0f,   0.0f,   0.0f,     //fig7
        //--- capa 7 ---
        1.95f, -18.25f,     0.0f,  0.0f, 0.0f,    //fig18
        3.797f, -18.25f,     0.0f,   0.0f,   0.0f,     //fig8
        //--- capa 8 ---
        2.06f, -18.25f,     5.82f,  -90.0f, 0.448f,    //fig19
        3.797f, -18.25f,     0.0f,   0.0f,   0.0f,     //fig9
        //--- capa 9 ---
        1.99f, -18.25f,     0.2f,  90.0f, 0.03f,    //fig20
        3.797f, -18.25f,     0.0f,   0.0f,   0.0f,     //fig10
        //--- capa 10 ---
        3.797f, -18.25f,     -90.0f,   0.0f,   0.0f,     //fig11
        //--- capa 11 ---
        3.797f, -18.25f,     90.0f,  13.056f, 0.0f,     //fig12
        //--- capa 12 ---
        3.797f, -18.25f,     0.0f,   0.0f,   0.0f,    //fig13
        0.28f,  -18.25f,     0.0f,   0.0f,   0.0f     //fig28

    };

    private int indice = 0;
    private int figura = 0;
    private int paredActivada = 0;

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
        TirarFiguras();

    }


    void CrearFigura()
    {
        if (Input.GetButtonDown("Jump") && figura < 28)
        {
            GameObject enemigoInst = Instantiate(listaFiguras1[figura], new Vector3(coords[indice], 10.0f,
                coords[indice + 1]), Quaternion.Euler(coords[indice + 2], coords[indice + 3], coords[indice + 4]));
            //GameObject enemigoInst2 = Instantiate(listaFiguras1[1], new Vector3(coords[5], Random.Range(6.27f, 10.0f),
             //   coords[6]), Quaternion.Euler(coords[7], coords[8], coords[9]));

            listaFiguras.Add(enemigoInst.gameObject);
            // listaFiguras.Add(enemigoInst2.gameObject);
            enemigoInst.transform.parent = figurasHIER.gameObject.transform;

            indice += 5;
            figura++;

        }
    }


    private void VerificarAltura()
    {
        foreach (GameObject enemigo in listaFiguras)
        {
            if (enemigo.transform.position.y < -10)
            {
                enemigo.transform.position = pos + new Vector3(0.5f, 5, 0);
            }
        }
    }

    private void OnMouseDown()
    {
        Pared();
    }

    void TirarFiguras()
    {
        if (Input.GetKey("down"))
        {
            ExplotarEnemigo();
        }
    }

    public void ExplotarEnemigo()
    {
        foreach (GameObject enemigo in listaFiguras)
        {
            Figuras en = enemigo.GetComponent<Figuras>();
            en.Explotar(pos);
        }

    }

    public void Pared()
    {
        if (paredActivada == 0)
        {
            GameObject paredInst = Instantiate(pared, new Vector3(2.2f, 3.5f, -8.2f),
                Quaternion.Euler(0.0f, 180.0f, 0.0f));
            paredInst.transform.parent = figurasHIER.gameObject.transform;
            paredActivada = 1;
        }
    }

}
