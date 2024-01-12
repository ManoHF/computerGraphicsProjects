using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figuras : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    private int explotar = 0;

    public Rigidbody Rigidbody
    {
        get { return rigidBody; }
        set { rigidBody = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (explotar == 0) 
            rigidBody.isKinematic = true;
        else if (explotar == 1)
            rigidBody.isKinematic = false;
    }


    public void Explotar(Vector3 pos)
    {
        explotar = 1;
        rigidBody.isKinematic = false;
        //rigidBody.AddExplosionForce(3, pos, 100, 10, ForceMode.Impulse);
        rigidBody.AddTorque(new Vector3(0, 50, 0), ForceMode.Force);
    }
}
