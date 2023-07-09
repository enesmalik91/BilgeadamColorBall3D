using System;
using System.Collections;
using DG.Tweening;
using TMPro;
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
    [SerializeField] private TMP_Text currentCoinText;

    [Header("Total Coin")] 
    [SerializeField] private string coinPref;
    [SerializeField] private TMP_Text totalCoinText;
    [SerializeField] private int currentCoin;

    [Header("Tap To Start")] 
    [SerializeField] private GameObject tapToStartParent;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        totalCoinText.text = PlayerPrefs.GetInt(coinPref, 0).ToString();
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
        currentCoinText.text = "+" + currentCoin;
        radialParent.SetActive(true);
        yield return new WaitForSeconds(2f);
        nextButton.SetActive(true);
    }

    public void IncreaseCoin()
    {
        currentCoin++;
        PlayerPrefs.SetInt(coinPref, PlayerPrefs.GetInt(coinPref) + 1);
        totalCoinText.text = PlayerPrefs.GetInt(coinPref, 0).ToString();
    }

    public void CloseTopToStart()
    {
        tapToStartParent.SetActive(false);
    }
}
