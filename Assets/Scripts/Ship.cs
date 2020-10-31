using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private int _speed;

    public GameObject shot;

    void Start()
    {
        this._speed = 10;
    }

    void Update()
    {
        this.movimentX();
        this.movimentY();

        if (Input.GetKeyDown("space"))
        {
            this.instantiateShot();
        }
    }

    private void movimentX()
    {
        float xAxis = ((Input.GetAxis("Horizontal") * _speed) * Time.deltaTime);
        transform.Translate(xAxis, 0, 0);
    }

    private void movimentY()
    {
        float yAxis = ((Input.GetAxis("Vertical") * _speed) * Time.deltaTime);
        transform.Translate(0, yAxis, 0);
    }

    private void instantiateShot()
    {
        Instantiate(shot, transform.position, Quaternion.identity);
    }
}
