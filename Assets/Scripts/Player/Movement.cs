using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 30f;
    [SerializeField] private float _curSpeed = 0f;
    [SerializeField] private float _timeAcceleration;
    [SerializeField] private GameObject _skinBoat;
    private Rigidbody2D _rb;

    private bool _move;
    private bool _left;
    private void Start() 
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if(_move && _left)
        {
            if(_curSpeed <= _maxSpeed)
                _curSpeed += Time.deltaTime/_timeAcceleration;
            Vector2 direction = new Vector3(1, 0);
            _rb.AddForce(direction * _curSpeed);
            _skinBoat.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        
        if(_move && !_left)
        {
            if(_curSpeed <= _maxSpeed)
                _curSpeed += Time.deltaTime/_timeAcceleration;
            Vector2 direction = new Vector3(-1, 0);
            _rb.AddForce(direction * _curSpeed);
            _skinBoat.transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        if(!_move && _rb.velocity.x > 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x - Time.deltaTime, 0);
        }
    }

    public void ResetSpeed() => _curSpeed = 0;
    public void Move(bool move) => _move = move;
    public void Direction(bool direction) => _left = direction;

    
}  
