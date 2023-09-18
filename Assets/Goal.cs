using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winText;

    bool gameOver;
    void Start()
    {
        winText.enabled = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) return;

        if (Input.GetKeyDown(KeyCode.R))

        { 
            // reset
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entro al trigger: " + other.gameObject.name);

        if (!other.gameObject.CompareTag("Player"))  return;
   
        Debug.Log("Entro el Player");
        winText.enabled = true;
        gameOver = true;
    }

}
