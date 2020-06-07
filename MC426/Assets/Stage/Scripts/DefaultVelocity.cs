﻿using UnityEngine;

public class DefaultVelocity : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(velocity);
    }
}