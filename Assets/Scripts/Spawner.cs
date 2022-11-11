using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    float tiempoMinimo = 0f;
    float tiempoMaximo = 5f;
    
    public GameObject lata;


    private void Update()
    {
        Instantiate(lata, transform.position - new Vector3(0f, 2f, 0f), Quaternion.identity);
    }

    // Mirar el Invoke y la rotación de la lata.
}
