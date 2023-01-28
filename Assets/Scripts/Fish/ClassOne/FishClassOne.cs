using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishClassOne : MonoBehaviour
{
   [SerializeField] private float _speed;
   [Header("Radius")]
   [SerializeField] private float _radius;
   
   [Header("Time")]
   [SerializeField] private float _maxTimeMovement;
   [SerializeField] private float _curTimeMovement;
   [SerializeField] private float _maxTime;

   [Header("Bool")]
   [SerializeField] private bool _startMovement;
   [Header("MovePoint")]
   

   [SerializeField] Rigidbody2D rb;

   private void Start()
   {
        _startMovement = true;
        rb = GetComponent<Rigidbody2D>();
        Movementfish();
   }
    private void Movementfish()
    {
       
        
            if(_startMovement == true && _curTimeMovement <= 0)
            {
                Vector2 centrPoint = transform.position;
                Vector2 randomPoint = centrPoint + new Vector2(Random.value-0.5f,Random.value-0.5f).normalized * _radius;
                rb.velocity = (transform.position * randomPoint) * _speed * Time.deltaTime;
            }
        
        
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.localPosition, _radius);
    }
     
    private void Timers()
    {
        _maxTimeMovement = Random.Range(0, _maxTime);
        _curTimeMovement = Random.Range(0, 11);
    }
    private void Update()
    {
        Vector2 centrPoint = transform.position;
        Vector2 randomPoint = centrPoint + new Vector2(Random.value-0.5f,Random.value-0.5f).normalized * _radius;
        randomPoint.Normalize();
        rb.velocity =   randomPoint * _speed * Time.deltaTime;
    }
   
}
