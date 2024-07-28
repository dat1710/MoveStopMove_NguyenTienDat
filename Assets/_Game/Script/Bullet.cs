using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : GameUnit
{
    [SerializeField] Rigidbody rb;
    [SerializeField] private float time = 2f;
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float rotationSpeed;
    public Character shooter;
    private Vector3 start;
    private Vector3 direction;
    private void Start()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
        transform.localScale = new Vector3(300, 300, 300);
    }
    private void Update()
    {
        Vector3 newPosition = transform.position + direction * moveSpeed * Time.deltaTime;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime, Space.World);
        Invoke("OnDespawn", time);
    }
    public void Fire(Vector3 start, Vector3 targetPosition)
    {
        this.direction = (targetPosition - start).normalized;
        transform.position = start;
    }
    public void OnDespawn()
    {
        HBPool.Despawn(this);
    }
}
