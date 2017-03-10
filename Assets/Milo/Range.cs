using UnityEngine;

public class Range : MonoBehaviour
{
   [SerializeField] private Transform _other;
    private float _targetRadius;

    [SerializeField] private LayerMask _layerMask;


    private void InRange()
    {
        if (!_other) return;
        var distance = Vector3.Distance(_other.position, transform.position);
        print("Distance to other object is: " + distance);
    }

    private void Update()
    {
        InRange();
    }
}
