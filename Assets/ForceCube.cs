using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCube : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    [SerializeField] float force;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))

        { rb.AddForce(Vector3.forward * force, ForceMode.Force); }
        
        if (Input.GetKey(KeyCode.R)) {

            rb.AddTorque(Vector3.up * force);
        
        }
    }
}
