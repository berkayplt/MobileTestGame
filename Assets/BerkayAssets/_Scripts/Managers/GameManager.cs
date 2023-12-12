using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGamePause = true;
    public Material ballAndRoadMat;

    [SerializeField] private GameObject StartPanel, LevelCompletePanel, GameOverPanel;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        OnBeginGame();
    }

    //Beginning of the game, a new level is created and the starting canvas appears
    private void OnBeginGame()
    {
        isGamePause = true;
        StartPanel.SetActive(true);

        if (LevelManager.Instance != null)
            LevelManager.Instance.CreateLevelOnStart(); 
    }

    /* Method works after the level is completed successfully, 
    the player's movement stops and the LevelComplete Panel appears.*/
    public void LevelComplete()
    {
        LevelManager.Instance.LevelUp();
        isGamePause = true;
        PlayerManager.Instance.isInputEnable = false;
        PlayerManager.Instance.isPlayerBoost = false;
        LevelCompletePanel.SetActive(true);

    }

    //Method is called when the player fails the game.
    public void GameOver()
    {
        isGamePause = true;
        PlayerManager.Instance.isInputEnable = false;
        GameOverPanel.SetActive(true);
    }

    //Closes all panels.
    public void ClosePanels()
    {
        StartPanel.SetActive(false);
        LevelCompletePanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    //Provides the material needed for the road and balls.
    public void SetBallAndRoadMat(Material newMaterial)
    {
        ballAndRoadMat = newMaterial;
    }

}
