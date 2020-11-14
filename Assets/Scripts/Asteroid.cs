using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private int _speed = -5;
    private Rigidbody2D _rigidbody;
    private PontuationController _pontuationController;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _pontuationController = GameObject.Find("Pontuation").GetComponent<PontuationController>();

        addVelocity();
        addRotation();
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            _pontuationController.score++;
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void addVelocity()
    {
        _rigidbody.velocity = new Vector2(0, _speed);
    }

    private void addRotation()
    {
        _rigidbody.angularVelocity = Random.Range(-200, 200);
    }
}
