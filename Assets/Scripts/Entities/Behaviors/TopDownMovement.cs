using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour 
{
    private TopDownController controller;
    private Rigidbody2D rigidBody;
    
    private SpriteRenderer characterRenderer;
    
    [SerializeField] 
    [Range(1f, 100f)] private float speed;

    private Vector2 movementDirection = Vector2.zero;

    private void Awake() 
    {
        controller = GetComponent<TopDownController>();
        rigidBody = GetComponent<Rigidbody2D>();    
        characterRenderer = GetComponentInChildren<SpriteRenderer>();
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
        rigidBody.velocity = direction;
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void Flip(Vector2 direction)
    {  
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }

}