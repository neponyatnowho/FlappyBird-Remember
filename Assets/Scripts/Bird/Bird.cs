using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private int _score;
    public event UnityAction GameOver;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
    }

    public void IncreaceScore()
    {
        _score++;
    }

    public void ResetPlayer()
    {
        _score = 0;
        _mover.ResetBiord();
    
    }

    public void Die()
    {
        GameOver?.Invoke();
    }



}
