using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private int _speed = 6;

    void Start()
    {
        Rigidbody2D _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.velocity = new Vector2(0, _speed);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
