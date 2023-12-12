using UnityEngine;

public class FinishLineScript : MonoBehaviour, Iinteractible
{
    public void Interact()
    {
        GoForFinish();
    }

    private void GoForFinish()
    {
        //Increases the player's speed for end-game acceleration
        PlayerManager.Instance.isPlayerBoost = true;

        LevelManager.Instance.CreateNextLevel();
        gameObject.SetActive(false);
    }

}
