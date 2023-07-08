using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [SerializeField] private Image failImage;
    [SerializeField] private float failImageDuration;

    [SerializeField] private GameObject restartButton;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenFailImage()
    {
        failImage.DOFade(1, failImageDuration).OnComplete((() => failImage.DOFade(0, failImageDuration)));
    }

    public IEnumerator OpenRestartButton()
    {
        yield return new WaitForSeconds(1f);
        
        restartButton.SetActive(true);
    }
}
