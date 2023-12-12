using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private float slideSpeed;
    [SerializeField] private float playerBoostedSpeed;

    private Rigidbody _rb;
    private Touch _touch;
    private Vector3 _clampPos;

    private float _maxPosition = 3;
    private float _slideTransformV;
    private float _hold_PlayerSpeed;
    private float _hold_PlayerSlideSpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        //Keep player movement speeds
        _hold_PlayerSpeed = playerSpeed;
        _hold_PlayerSlideSpeed = slideSpeed;
    }


    void Update()
    {
        InputMethod();
        Movement();
    }

    //Allows the character to move
    private void Movement()
    {
        _rb.velocity = new Vector3(_slideTransformV, 0, playerSpeed);

        _clampPos = transform.position;
        _clampPos.x = Mathf.Clamp(_clampPos.x, -_maxPosition, _maxPosition);
        transform.position = _clampPos;
    }

    //Check Player Inputs
    private void InputMethod()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Moved && PlayerManager.Instance.isInputEnable) 
            {
                GameManager.Instance.isGamePause = false;
                _slideTransformV = _touch.deltaPosition.x * slideSpeed;
            }
            else
                _slideTransformV = 0;

        }
    }

    //Make the player's speed equal to the predetermined boost value
    public void SpeedBoost()
    {
        playerSpeed = playerBoostedSpeed;
    }

    //Stops the player's forward speed and slide speed.
    public void FullStop()
    {
        playerSpeed = 0;
        slideSpeed = 0;
    }

    //Only stops the player's forward movement speed.
    public void StopForward()
    {
        playerSpeed = 0;
    }

    //Moves the player again with the speed values kept at the beginning of the game.
    public void MoveStart()
    {
        playerSpeed = _hold_PlayerSpeed;
        slideSpeed = _hold_PlayerSlideSpeed;
    }

}
