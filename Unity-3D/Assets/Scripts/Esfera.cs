using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esfera : MonoBehaviour
{
    private Vector3 pos;
    [SerializeField] private GameObject enemigo;
    [SerializeField] private GameObject enemigo2;
    [SerializeField] private List<GameObject> listaEnemigos = new List<GameObject>();
    private GameObject enemigoHIER;
    // este se usa para guardar toda la info del objeto GameObject todo;

    public List<GameObject> ListaEnemigos
    {
        get { return listaEnemigos; }
        set { listaEnemigos = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        enemigoHIER = new GameObject();
        enemigoHIER.name = "GrupoEnemigos";
    }

    // Update is called once per frame
    void Update()
    {
        CrearEnemigo();
        VerificarAltura();
    }

    void CrearEnemigo()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GameObject enemigoInst = Instantiate(enemigo, new Vector3(Random.Range(-7.16f, 4.86f), Random.Range(6.27f, 10.0f), Random.Range(-4.37f, 4.55f)), Quaternion.Euler(0, 0, 0));
            GameObject enemigoInst2 = Instantiate(enemigo2, new Vector3(Random.Range(-7.16f, 4.86f), Random.Range(6.27f, 10.0f), Random.Range(-4.37f, 4.55f)), Quaternion.Euler(0, 0, 0));

            float escala = Random.Range(0.5f, 1.5f);
            enemigoInst.transform.localScale = new Vector3(escala, escala, escala);
            listaEnemigos.Add(enemigoInst.gameObject);
            listaEnemigos.Add(enemigoInst2.gameObject);
            enemigoInst.transform.parent = enemigoHIER.gameObject.transform;
            enemigoInst2.transform.parent = enemigoHIER.gameObject.transform;
            //enemigoInst2.transform.parent = enemigoHIER2.gameObject.transform;
        }
    }

    private void VerificarAltura()
    {
        foreach (GameObject enemigo in listaEnemigos)
        {
            if (enemigo.transform.position.y < -10)
                enemigo.transform.position = pos + new Vector3(0.5f, 5, 0);
        }
    }

    private void OnMouseDown()
    {
        ExplotarEnemigo();
    }

    public void ExplotarEnemigo()
    {
        foreach(GameObject enemigo in listaEnemigos)
        {
            Enemigo en = enemigo.GetComponent<Enemigo>();
            en.Explotar(pos);
        }
                
    }
}
