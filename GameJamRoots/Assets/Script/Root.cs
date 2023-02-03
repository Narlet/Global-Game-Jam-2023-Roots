using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private int _length = 10;
    [SerializeField] private LineRenderer _lineRend = null;
    [SerializeField] private Vector3[] _segmentPoses = null;
    [SerializeField] private Transform _targetDir = null;
    [SerializeField] private float _targetDist = 10;
    [SerializeField] private float _smoothSpeed = 5;
    [SerializeField] private float _trailSpeed = 350;

    private Vector3[] _segmentV = null;
    // Start is called before the first frame update
    void Start()
    {
        _lineRend.positionCount = _length;
        _segmentPoses = new Vector3[_length];
        for (int i = 1; i < _segmentPoses.Length; i++)
        {
            _segmentPoses[i] = _targetDir.position;
        }
        _segmentV = new Vector3[_length];
    }

    // Update is called once per frame
    void Update()
    {
        _segmentPoses[0] = _targetDir.position;

        for(int i = 1; i < _segmentPoses.Length; i++)
        {
            _segmentPoses[i] = Vector3.SmoothDamp(_segmentPoses[i], _segmentPoses[i - 1] + _targetDir.right * _targetDist, ref _segmentV[i], _smoothSpeed + i / _trailSpeed);
        }
        _lineRend.SetPositions(_segmentPoses);
    }
}
