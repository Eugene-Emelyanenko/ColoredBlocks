using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float speed = 3f;
    public string currentColor;
    public Sprite[] colors;

    private Animator _animator;
    private Bank _clickedBank;
    private bool canMove = false;

    private void Start()
    {
        Bank.canSelectBank = true;
        _animator = GetComponent<Animator>();
        ChangeColor();
    }

    public void MoveBall(Bank bank)
    {
        Bank.canSelectBank = false;
        canMove = true;
        _clickedBank = bank;
    }

    private void Update()
    {
        _animator.SetBool("canMove", canMove);
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, _clickedBank.transform.position, speed * Time.deltaTime);
            if (transform.position == _clickedBank.transform.position)
            {
                if(_clickedBank.currentColor == currentColor)
                    _clickedBank.Broken();
                Destroy(this.gameObject);
                FindObjectOfType<Steps>().Step();
            }
        }
    }
    
    private void ChangeColor()
    {
        int rand = Random.Range(0, colors.Length - 1);
        currentColor = colors[rand].name;
        GetComponent<SpriteRenderer>().sprite = colors[rand];
    }

    private void OnDestroy()
    {
        FindObjectOfType<BallGenerator>().isDestroyed = true;
    }
}
