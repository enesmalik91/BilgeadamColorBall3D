using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RadialShine : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        //transform.DORotate(new Vector3(0, 0, rotationSpeed), .1f).SetLoops(-1, LoopType.Incremental);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
    }
}
