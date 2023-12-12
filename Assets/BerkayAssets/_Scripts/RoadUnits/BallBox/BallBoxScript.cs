using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallBoxScript : MonoBehaviour
{
    [SerializeField] private TMP_Text _ballCountText;
    [SerializeField] private BoxRoadScript _boxRoad;
    [SerializeField] private BoxBridgeScript _boxBridge;

    [Header("Values")]
    [SerializeField] private List<BallScript> _balls;
    [SerializeField] private int _targetBallCount;
    [SerializeField] private int _currentBallCount;

    [Header("PassTimeSettings")]
    [SerializeField] private float _passCheckTime;
    [SerializeField] private float _passStartTime;
    [SerializeField] private float _passOpenRoadTime;
    [SerializeField] private float _passOpenBridgeTime;
    [SerializeField] private float _passAfterBridgeTime;

    private WaitForSeconds _passCheckWait;
    private WaitForSeconds _passStartWait;
    private WaitForSeconds _passOpenRoadWait;
    private WaitForSeconds _passOpenBridgeWait;
    private WaitForSeconds _passAfterBridgeWait;


    private void Start()
    {
        SetOnStart();
    }

    private void SetOnStart()
    {
        _ballCountText = transform.Find("BallCountText").GetComponent<TMP_Text>();
        _boxRoad = transform.Find("BoxRoad").GetComponent<BoxRoadScript>();
        _boxBridge = transform.Find("BoxBridge").GetComponent<BoxBridgeScript>();

        _passCheckWait = new WaitForSeconds(_passCheckTime);
        _passStartWait = new WaitForSeconds(_passStartTime);
        _passOpenRoadWait = new WaitForSeconds(_passOpenRoadTime);
        _passOpenBridgeWait = new WaitForSeconds(_passOpenBridgeTime);
        _passAfterBridgeWait = new WaitForSeconds(_passAfterBridgeTime);

        _currentBallCount = 0;
        _ballCountText.text = _currentBallCount + "/" + _targetBallCount;
    }

    //Adds the balls entering the box to the List
    private void AddBallToBox(int addedBall, BallScript balls)
    {
        _currentBallCount += addedBall;  
        _ballCountText.text = _currentBallCount + "/" + _targetBallCount;
        _balls.Add(balls);      
    }

    public void StartPassCheck()
    {
        StartCoroutine(PassCheck());
    }

    /*After the waiting period, it checks whether the player
    passes or not, depending on the amount of balls in the list */
    public IEnumerator PassCheck()
    {
        yield return _passCheckWait;
        if(_currentBallCount >= _targetBallCount)
        { 
            StartCoroutine(Pass()); 
        }
        else if(_currentBallCount < _targetBallCount) 
        {
            NotPass(); 
        }
    }

    /*It starts the pass process, first the destroy process of the balls begins, 
     * then the road pass process begins, and finally the bridge is opened*/
    private IEnumerator Pass()
    {
        yield return _passStartWait;
        for (int i = 0; i < _balls.Count; i++)
        {
            _balls[i].DestroyBall();
        }
        yield return _passOpenRoadWait;
        _boxRoad.StartRoadPass();
        yield return _passOpenBridgeWait;
        _boxBridge.StartBridgePass();
        LevelManager.Instance.IncreaseLevelBar();
        yield return _passAfterBridgeWait;

       PlayerManager.Instance.isPlayerStop = false;
    }

    private void NotPass()
    {
        GameManager.Instance.GameOver();
    }


    private void OnTriggerEnter(Collider other)
    {
       
        ICollectible collectible = other.GetComponent<ICollectible>();

        if (collectible != null)
        {
            BallScript ballScript = other.GetComponent<BallScript>();
            AddBallToBox(1, ballScript);
        }
    }

   
}
