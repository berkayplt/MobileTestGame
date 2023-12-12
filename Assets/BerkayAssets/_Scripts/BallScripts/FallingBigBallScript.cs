using UnityEngine;

public class FallingBigBallScript : MonoBehaviour
{
    [SerializeField] private GameObject balls;
    [SerializeField] private GameObject bigBallSphere;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void ActiveGravity()
    {
        _rb.useGravity = true;
    }

    private void OnHitGround()
    {
        balls.SetActive(true);
        bigBallSphere.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        OnHitGround();
    }
}
