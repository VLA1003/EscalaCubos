using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    bool hitDone = false;
    public void ClickOnCube()
    {
        if (hitDone == false)
        {
            LeanTween.scale(gameObject, Vector3.one * 1.5f, 0.7f).setEaseOutElastic();
            hitDone = true;
        }
        else
        {
            LeanTween.scale(gameObject, Vector3.one * 1f, 0.7f).setEaseOutElastic();
            hitDone = false;
        }

    }
}
