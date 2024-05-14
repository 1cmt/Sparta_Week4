using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour 
{
    private TopDownController controller;
    private Rigidbody2D rigidBody;
    
    [SerializeField] private SpriteRenderer characterRenderer;
    
    [SerializeField] 
    [Range(1f, 100f)] private float speed;

    private Vector2 movementDirection = Vector2.zero;

    private void Awake() 
    {
        controller = GetComponent<TopDownController>();
        rigidBody = GetComponent<Rigidbody2D>();    
    }
    
    private void Start() 
    {
        controller.OnMoveEvent += Move;    
        controller.OnLookEvent += Flip;    
    }

    private void FixedUpdate() 
    {
        ApplyMovement(movementDirection);    
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * speed;
        Debug.Log(direction);
        rigidBody.velocity = direction;
    }

    private void Move(Vector2 direction)
    {
        Debug.Log("Move"); //Move함수 자체가 호출이 안됩니다.
        movementDirection = direction;
    }

    private void Flip(Vector2 direction)
    {  
        Debug.Log("Flip"); //Flip함수 자체가 호출이 안됩니다.
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }

}