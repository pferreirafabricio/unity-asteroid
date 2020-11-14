using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    private int _speed = 8;

    private float _maxPositionX = 5.6f;
    private float _minPositionX = -5.6f;

    private float _maxPositionY = 4.5f;
    private float _minPositionY = -4.5f;

    public GameObject shot;
    public Text uiLifeText;
    public int quantityLifes;
    public AudioClip audioClip;

    void Start()
    {
        this.quantityLifes = 5;
        updateTextLifes();
    }

    void Update()
    {
        movimentX();
        movimentY();
        limitHorizontalMoviment();
        limitVerticalMoviment();

        if (Input.GetKeyDown("space"))
            instantiateShot();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            quantityLifes--;
            updateTextLifes();
            AudioSource.PlayClipAtPoint(audioClip, transform.position);

            if (quantityLifes == 0)
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene("menu", LoadSceneMode.Single);
            }
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

    private void limitHorizontalMoviment()
    {
        if (transform.position.x <= _minPositionX || transform.position.x >= _maxPositionX)
        {
            float positionX = Mathf.Clamp(transform.position.x, _minPositionX, _maxPositionX);
            transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
        }
    }

    private void limitVerticalMoviment()
    {
        if (transform.position.y <= _minPositionY || transform.position.y >= _maxPositionY)
        {
            float positionY = Mathf.Clamp(transform.position.y, _minPositionY, _maxPositionY);
            transform.position = new Vector3(transform.position.x, positionY, transform.position.z);
        }
    }

    private void updateTextLifes()
    {
        uiLifeText.text = "Vidas: " + quantityLifes;
    }
}
