using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    private Renderer rend;
    private Esfera esf;

    public Rigidbody Rigidbody
    {
        get { return rigidBody; }
        set { rigidBody = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        
        rend.material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        esf = GameObject.Find("Sphere").GetComponent<Esfera>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explotar(Vector3 pos)
    {
        rigidBody.AddExplosionForce(10, pos, 100, 10, ForceMode.Impulse);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            int index = esf.ListaEnemigos.IndexOf(gameObject);
            Destroy(esf.ListaEnemigos[index]);
            esf.ListaEnemigos.RemoveAt(index);
            
        }
    }
}
