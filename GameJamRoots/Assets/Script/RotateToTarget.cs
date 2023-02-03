using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 10;
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private bool _stopMoving = false;
    private Vector2 _direction = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StopMoving();
        RotateToMousePosition();
        MoveToMousePosition();
    }


    void RotateToMousePosition()
    {
        _direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }

    void MoveToMousePosition()
    {
        if (!_stopMoving)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.MoveTowards(transform.position, cursorPos, _moveSpeed * Time.deltaTime);
        }
    }

    void StopMoving()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("zwehw");
            _stopMoving = true;
        }
        else
        {
            _stopMoving = false;
        }
    }
}
