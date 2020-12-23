﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableMonster : Monster
{
    [SerializeField]
    private float speed = 2.0F;

    private Bullet bullet;

    private SpriteRenderer sprite;

    private Vector3 direction; 

    protected override void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");
    }

    protected override void Start()
    {
        direction = transform.right;
    }
    protected override void Update()
    {
        Move();
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>();

        if (bullet) ReceiveDamage();
    }


    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * direction.x * 0.7F, 0.2F);
        if (colliders.Length > 0) direction *= -1.0F;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}