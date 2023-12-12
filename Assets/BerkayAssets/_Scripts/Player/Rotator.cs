using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotateXangle, rotateYangle, rotateZangle;

    private void Update()
    {
        transform.Rotate(rotateXangle, rotateYangle, rotateZangle);
    }
}
