using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Bird))]
public class BirdCollisionHeandler : MonoBehaviour
{
    private Bird _bird;

    private void Start()
    {
        _bird = GetComponent<Bird>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out ScoreZone scorezone))
        {
            _bird.IncreaceScore();
        }
        else
        {
            _bird.Die();

        }

    }
}
