using UnityEngine;

public class BallBoxStop : MonoBehaviour, Iinteractible
{
    [SerializeField] private BallBoxScript _ballBoxScript;

    /*It allows the to throw the balls player has collected and activates
    the BallBoxScript that collects the balls*/
    private void EnableThrow()
    {        
        PlayerManager.Instance.ThrowBalls();
        _ballBoxScript.StartPassCheck();
        gameObject.SetActive(false);
    }

    public void Interact()
    {
        EnableThrow();
    }
}
