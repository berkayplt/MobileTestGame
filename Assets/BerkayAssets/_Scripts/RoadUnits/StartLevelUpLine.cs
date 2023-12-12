using UnityEngine;

public class StartLevelUpLine : MonoBehaviour, Iinteractible
{
    public void Interact()
    {
        PassLevelandStart();
    }

    private void PassLevelandStart()
    {
        GameManager.Instance.LevelComplete();
        gameObject.SetActive(false);
    }
}

