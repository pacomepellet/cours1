using UnityEngine;

public class RotateLoop : MonoBehaviour
{
    [SerializeField] private GameObject pivot;
    [SerializeField] private float rotationSpeed = 5;
    [SerializeField] private Vector3 rotationVector;
    [SerializeField] private float minRotation;
    [SerializeField] private float maxRotation;

    private Vector3 _rotationDirection;
    private float _currentRotation;
    private bool _isIncreasing = true;

    private void Awake()
    {
        _currentRotation = minRotation;
        _rotationDirection = rotationVector.normalized;
        transform.rotation = Quaternion.Euler(_rotationDirection * minRotation);
    }

    void Update()
    {
        float appliedRotation = 0;
        
        // À Compléter
        
        transform.RotateAround(pivot.transform.position, _rotationDirection, appliedRotation);
    }
}
