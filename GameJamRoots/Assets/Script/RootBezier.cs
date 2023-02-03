using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootBezier : MonoBehaviour
{
    [SerializeField] private List<Vector2> _positions = null;
    [SerializeField] private Transform _characterTransform = null;
    [SerializeField] private PathCreator _pathcreator = new PathCreator();
    [SerializeField] private float _maxDelayTime = 1;
    private float _currentDelayTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        _positions.Add(_characterTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentDelayTime >= _maxDelayTime)
        {
            _positions.Add(_characterTransform.position);
            Vector2[] allPositions = new Vector2[_positions.Count];
            for (int i = 0; i < _positions.Count; i++)
            {
                allPositions[i] = _positions[i];
            }
            _pathcreator.bezierPath = GeneratePath(allPositions, false);
            _currentDelayTime = 0;
        }
        _currentDelayTime += Time.deltaTime;
    }

    BezierPath GeneratePath(Vector2[] points, bool closedPath)
    {
        BezierPath bezierPath = new BezierPath(points, closedPath, PathSpace.xy);
        return bezierPath;
    }
}
