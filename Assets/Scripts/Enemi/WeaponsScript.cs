using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsScript : MonoBehaviour
{
    private float _speed = 2;
    private float _endPosX;

    public void StartFloating(float speed, float endPosX)
    {
        _speed = speed;
        _endPosX = endPosX;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * (Time.deltaTime * _speed));

        if(transform.position.y < _endPosX)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement.instancie.live -= 3;
            Destroy(gameObject);
        }
    }
}
