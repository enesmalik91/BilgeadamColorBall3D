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

    [Header("Complete Settings")] 
    [SerializeField] private GameObject completePanel;

    [SerializeField] private GameObject radialParent;
    [SerializeField] private GameObject nextButton;
    

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

    public IEnumerator OpenCompletePanel()
    {
        yield return new WaitForSeconds(0.1f);
        completePanel.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        radialParent.SetActive(true);
        yield return new WaitForSeconds(2f);
        nextButton.SetActive(true);
    }
}
