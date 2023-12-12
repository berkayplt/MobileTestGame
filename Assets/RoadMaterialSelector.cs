using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMaterialSelector : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Renderer _renderer;
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
       _material = _renderer.material;
      
        GameManager.Instance.ballAndRoadMat = _renderer.material;
    }
}
