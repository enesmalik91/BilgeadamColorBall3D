using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndSlider : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject finishLine;

    [SerializeField] private TMP_Text left;
    [SerializeField] private TMP_Text right;

    private float currentDistance;
    private float totalDistance;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        finishLine = GameObject.FindGameObjectWithTag("Finish");
        totalDistance = Vector3.Distance(player.transform.position, finishLine.transform.position);

        left.text = PlayerPrefs.GetInt("Level", 1).ToString();
        right.text = (PlayerPrefs.GetInt("Level", 1) + 1).ToString();
    }

    private void Update()
    {
        currentDistance = Vector3.Distance(player.transform.position, finishLine.transform.position);
        fillImage.fillAmount = 1 - (currentDistance / totalDistance);
    }
}
