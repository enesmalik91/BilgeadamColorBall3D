using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            Debug.Log("Collectable");
            UIManager.Instance.IncreaseCoin();
        }
    }
}
