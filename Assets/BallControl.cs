using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;
using JetBrains.Annotations;

public class BallControl : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] LayerMask m_LayerMask;
    [SerializeField] private float force;
    [SerializeField] private float jumpForce;

    [SerializeField]  Rigidbody rb;
    [SerializeField] SphereCollider sphereCollider;

    [SerializeField] private int score;

    private int totalItems;

    [SerializeField] TextMeshProUGUI scoreText;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();

        totalItems = GameObject.FindGameObjectsWithTag("Item").Length;
        UpdateScore();

        // hago algo
    }

    private void Update()
    {
        
        
        if(Input.GetKeyUp(KeyCode.Space)) {

            if (Physics.CheckSphere(sphereCollider.bounds.center, sphereCollider.radius, m_LayerMask))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

           
        }
    }



    private void FixedUpdate()

    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        rb.AddForce(direction.normalized * force, ForceMode.Force);

    }

    private void OnCollisionEnter(Collision collision)
    {
       Debug.Log("Choque contra: " + collision.gameObject.name );

        if (collision.gameObject.CompareTag("Item"))
        {
            ScoreUp(collision);

        }

        if (collision.gameObject.CompareTag("Kill")) {

            SceneManager.LoadScene(0);     
        }
    }

    private void ScoreUp(Collision collision)
    {
        Debug.Log("ITEMMM >>>>>>>>>>>>>>>>");
        Destroy(collision.gameObject);
        score++;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString() + " / " + totalItems.ToString();
    }

}

