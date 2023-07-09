using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject level;
    public int currentLevel;
    public int totalLevelCount;
    public TMP_Text level_text;

    public bool isFinish;
    public bool isStart;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("Level", 1);
        OpenCurrentLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
    private void OpenCurrentLevel()
    {
        //level_text.text = "" + (currentLevel);
        if (currentLevel > totalLevelCount)
        {
            Random.InitState(System.DateTime.Now.Millisecond);
            currentLevel = Random.Range(1, totalLevelCount + 1);
            level = (GameObject)Instantiate(Resources.Load("Level" + currentLevel));
        }
        else
        {
            level = (GameObject)Instantiate(Resources.Load("Level" + currentLevel));
        }
    }
    
    public void NextLevel()
    {
        Debug.Log("NExt level");
        PlayerPrefs.SetInt("Level", (PlayerPrefs.GetInt("Level", 1) + 1));
        RestartGame();
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
