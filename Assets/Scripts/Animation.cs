using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    void Start()
    {
        LeanTween.moveY(GetComponent<RectTransform>(), 50f, 1f).setLoopPingPong();
    }

}
