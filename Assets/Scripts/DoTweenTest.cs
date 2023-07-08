using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoTweenTest : MonoBehaviour
{
    [SerializeField] private Transform cube;
    private void Start()
    {
        //transform.DOMoveX(10, 1);

        //transform.DOMove(new Vector3(2, 4, 5), 1);

        //transform.DOPunchPosition(Vector3.one * 0.5f, 1);
        //transform.DOPunchScale(Vector3.one * 0.5f, 1);
        //transform.DOPunchRotation(Vector3.one * 50f, 1);

        transform.DOJump(cube.position, 5, 1, 1f);
    }
}
