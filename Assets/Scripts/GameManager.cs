using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI puntuacionInterfaz;
    
    public Material hitMaterial;
    public AudioClip shotSound;
    public AudioClip missSound;
    public AudioClip metallicHit;
    private AudioSource gunAudioSource;

    int puntuacion = 0;

    void Awake()
    {
        gunAudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        
        if((Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {
            gunAudioSource.PlayOneShot(shotSound);
            Vector3 pos = Input.mousePosition;
            if (Application.platform == RuntimePlatform.Android)
            { 
                pos = Input.GetTouch(0).position;
            }

            Ray rayo = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo) == true)
            {
                if (hitInfo.collider.tag.Equals("Lata"))
                {
                    gunAudioSource.PlayOneShot(metallicHit);
                    Rigidbody rigidbodyLata = hitInfo.collider.GetComponent<Rigidbody>();
                    rigidbodyLata.AddForce(rayo.direction * 50f, ForceMode.VelocityChange);
                    hitInfo.collider.GetComponent<MeshRenderer>().material = hitMaterial;
                    puntuacion = puntuacion + 10;
                    puntuacionInterfaz.text = puntuacion.ToString();
                }
            }
            else
            {
                gunAudioSource.PlayOneShot(missSound);
                puntuacion = puntuacion - 5;
                puntuacionInterfaz.text = puntuacion.ToString();
            }
        }
    }
}
