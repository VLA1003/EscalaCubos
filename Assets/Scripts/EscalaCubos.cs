using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalaCubos : MonoBehaviour
{
    void Update()
    {
        if ((Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {
            Vector3 pos = Input.mousePosition;
            if (Application.platform == RuntimePlatform.Android)
            {
                pos = Input.GetTouch(0).position;
            }

            Ray rayo = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo) == true)
            {
                if (hitInfo.collider.tag.Equals("Cubo"))
                {
                    hitInfo.collider.GetComponent<CubeBehaviour>().ClickOnCube();
                }
            }
        }
    }
}
