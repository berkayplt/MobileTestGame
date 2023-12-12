using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [SerializeField] private List<BallScript> balls;
    [SerializeField] private PlayerController controller;

    [Header("Settings")]
    [SerializeField] private float ballPushForce = 20;
    [SerializeField] private GameObject upgradePart;

    public bool isPlayerStop = false;
    public bool isPlayerBoost = false;
    public bool isInputEnable = true;
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
        controller = GetComponent<PlayerController>();
    }


    private void Update()
    {
      
        if (!GameManager.Instance.isGamePause) 
        {
            if (isPlayerStop)
            {
                PlayerForwardStop();
            }
            else if (isPlayerBoost)
            {
                PlayerSpeedBoost();
            }
            else
                PlayerToMove();

        }
        else if (GameManager.Instance.isGamePause) 
        {
            PlayerFullStop();
        }
    }

    //Open the rotating player upgrade
    public void OpenUpgradePart()
    {
        upgradePart.SetActive(true);
    }

    //Close the rotating player upgrade
    public void CloseUpgradePart()
    {
        upgradePart.SetActive(false);
    }

    //Added to the List where balls should be found.
    public void AddBall(BallScript ball)
    {
        balls.Add(ball);
    }

    //Deleted from the List where balls should be found.
    public void RemoveBall(BallScript ball)
    {
        balls.Remove(ball);
    }

    /*It stops the player and closes it if an upgrade piece is open.
    It throws all the balls in the "balls" list with the specified power.*/
    public void ThrowBalls()
    {
        CloseUpgradePart();
        isPlayerStop = true;
        for (int i = 0; i < balls.Count; i++)
        {
            if (balls[i] != null)
                balls[i].Throw(ballPushForce);
        }
    }

    public void PlayerToMove()
    {
        GameManager.Instance.ClosePanels();  //If the player moves, open panels close.
        controller.MoveStart();
    }

    public void PlayerFullStop()
    {
        controller.FullStop();
    }
    public void PlayerForwardStop()
    {
        controller.StopForward();
    }
    public void PlayerSpeedBoost()
    {
        controller.SpeedBoost();
    }

    private void OnTriggerEnter(Collider other)
    {
        Iinteractible interactible = other.GetComponent<Iinteractible>();  
        ICollectible collectible = other.GetComponent<ICollectible>();

        if (collectible != null)
        {
            collectible.Collect();
        }
        if (interactible != null)
        {
            interactible.Interact();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ICollectible collectible = other.GetComponent<ICollectible>();

        if (collectible != null)
        {
            collectible.Collect();
        }
    }
}
