using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _distance;

    private void Start()
    {
        _player = PlayerManager.Instance.transform;
    }
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _player.transform.position.z - _distance);

    }
}
