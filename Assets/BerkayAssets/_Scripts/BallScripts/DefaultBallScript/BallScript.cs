using System.Collections;
using UnityEngine;

public class BallScript : MonoBehaviour, ICollectible
{
    private Rigidbody _rb;
    private bool _isCollectible = false;
    private Renderer _renderer;
    private WaitForSeconds _timeForDestroy;
    [SerializeField] private Material roadMaterial;

    public void Collect()
    {
        AddRemoveToPlayer();

    }
    public void DestroyBall()
    {
        StartCoroutine(StartDestroy());
    }

    private void Start()
    {
        Invoke("SetOnStart", 0.2f);
    }

   
    private void SetOnStart()
    {
        _rb = GetComponent<Rigidbody>();

        _renderer = GetComponent<Renderer>();
        roadMaterial = GameManager.Instance.ballAndRoadMat;  //Gets the material used in the level's road by GameManager.
        _timeForDestroy = new WaitForSeconds(0.5f);
    }

    //It throws itself forward according to the determined force.
    public void Throw(float pushForce)
    {
        _rb.velocity = Vector3.forward * pushForce;
    }

    //Added or deleted from the player's collected ball list.
    private void AddRemoveToPlayer()
    {
        if (_isCollectible)
        {
            PlayerManager.Instance.RemoveBall(this);
            _isCollectible = false;
        }
        else if (!_isCollectible)
        {
            PlayerManager.Instance.AddBall(this);
            _isCollectible = true;
        }
    }


    private void ChangeColor()
    {
        _renderer.material = roadMaterial;
    }

    private IEnumerator StartDestroy()
    {
        ChangeColor();
        yield return _timeForDestroy;
        Destroy(gameObject);
    }

}
