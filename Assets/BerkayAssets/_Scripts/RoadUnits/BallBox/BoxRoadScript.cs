using UnityEngine;

public class BoxRoadScript : MonoBehaviour
{
    private Renderer _renderer;
    private Material _materialChange;
    private Vector3 _targetPosition;
    private bool isAnimateRoad = false;

    [Header("Settings")]
    [SerializeField] private float speed = 3;



    private void Start()
    {
        Invoke("SetOnStart", 0.2f);

    }

    private void SetOnStart()
    {
        _renderer = GetComponent<Renderer>();
        _materialChange = GameManager.Instance.ballAndRoadMat;   //Gets the material used in the level's road by GameManager.
        _targetPosition = new Vector3(transform.position.x, -4.39f, transform.position.z);
    }

    private void Update()
    {
        Movement();
    }
    public void Movement()
    {
        if (isAnimateRoad)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);
        }
    }

    public void StartRoadPass()
    {
        ChangeTheMaterial();
        AnimateCheck();
    }


    public void ChangeTheMaterial()
    {
        _renderer.material = _materialChange;
    }
    public void AnimateCheck()
    {
        isAnimateRoad = (isAnimateRoad == false) ? true : false;
    }
}
