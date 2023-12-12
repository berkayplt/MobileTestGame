using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.VersionControl;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    private Vector3 levelAtStartPos;
    private GameObject oldLevelGameObject;
    private int _currentProgress = -1;

    [Header("Level Info")]
    [SerializeField] private GameObject[] Levels;
    [SerializeField] private int currentLevel;

    [Header("Level UI")]
    [SerializeField] private TMP_Text currentLevelText;
    [SerializeField] private TMP_Text nextLevelText;
    [SerializeField] private Image[] levelBars;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        levelAtStartPos = new Vector3(1.09f, -3.608f, 47.86f);
    }
    public void LevelUp()
    {
       DeleteOldLevel();
       PlayerPrefs.SetInt("CurrentLevel", currentLevel);
    }

    //Create new level on start
    public void CreateLevelOnStart()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        GameObject newLevel = Levels[currentLevel];
        oldLevelGameObject =Instantiate(newLevel, levelAtStartPos, Quaternion.identity);
        TextLevels();
    }

    //After completing the default level, the next level is created.
    public void CreateNextLevel()
    {
        Transform oldLevelTransform = oldLevelGameObject.transform;
        Vector3 nextLevelPos = oldLevelTransform.position;

        currentLevel++;
        if(currentLevel >= Levels.Length)  //The reason I did this part is so that there are certain levels and those who study the game can play it constantly!!!.
        {
            currentLevel = 0;
        }
        GameObject newLevel = Levels[currentLevel];
        Instantiate(newLevel, new Vector3(nextLevelPos.x,nextLevelPos.y,nextLevelPos.z + 297.14f), Quaternion.identity); ;
    }

   
    public void DeleteOldLevel()
    {
        Destroy(oldLevelGameObject);
        oldLevelGameObject = null;
    }

    #region LevelUIPart

    //Changes the color of the Level Bars to orange one by one.
    public void IncreaseLevelBar()
    {
        _currentProgress++;
        if(_currentProgress < 3)
        levelBars[_currentProgress].color = new Color(1, 0.4829951f, 0, 1);
    }

    //Changes the texts on the level indicator.
    public void TextLevels()
    {
        currentLevelText.text = (currentLevel+1).ToString();
        nextLevelText.text = (currentLevel+2).ToString();
    }

    #endregion

}
