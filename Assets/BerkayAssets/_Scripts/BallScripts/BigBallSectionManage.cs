using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBallSectionManage : MonoBehaviour, Iinteractible
{
    [SerializeField] private List<FallingBigBallScript> fallingballScript;
    [SerializeField] private float waitTimeToFall;
    private WaitForSeconds _timeOut;

    private void Start()
    {
        _timeOut = new WaitForSeconds(waitTimeToFall);
        FindBallsOnStart();
    }

    public void Interact()
    {
        StartCoroutine(FallBallStart());
    }

    //It allows finding the balls to be activated in the GameObject.
    private void FindBallsOnStart()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            fallingballScript.Add(transform.GetChild(i).transform.GetChild(0).GetComponent<FallingBigBallScript>());
        }
    }


    private IEnumerator FallBallStart()
    {
        for (int i = 0; i < fallingballScript.Count; i++)
        {
            yield return _timeOut;
            fallingballScript[i].ActiveGravity();
        }
    }


}
