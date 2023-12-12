using UnityEngine;

public class BoxBridgeScript : MonoBehaviour
{
    [SerializeField] private Transform bridgePart1Pos, bridgePart2Pos;
    [SerializeField] private float bridgeSpeed;
    [SerializeField] private bool isBridgeActive;
    [SerializeField] private float bridgePart1TargetXrot = 0, bridgePart2TargetXrot = 0;
    [SerializeField]private Quaternion bridgePart1TargetRot, bridgePart2TargetRot;
    
    private void Start()
    {
        //Targeted positions of bridge parts.
        bridgePart1TargetRot = Quaternion.Euler(bridgePart1TargetXrot, 90, 90);
        bridgePart2TargetRot = Quaternion.Euler(bridgePart2TargetXrot, 90, 90);
    }

    private void Update()
    {
        Movement();
    }


    private void Movement()
    {
        if (isBridgeActive)
        {        
            bridgePart1Pos.rotation = Quaternion.Slerp(bridgePart1Pos.rotation, bridgePart1TargetRot, bridgeSpeed * Time.deltaTime);
            bridgePart2Pos.rotation = Quaternion.Slerp(bridgePart2Pos.rotation, bridgePart2TargetRot, bridgeSpeed * Time.deltaTime);
        }

    }

    public void StartBridgePass()
    {
        isBridgeActive = (isBridgeActive) ? false : true; 
    }
}
