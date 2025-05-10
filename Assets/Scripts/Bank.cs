using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Bank : MonoBehaviour
{
    public string currentColor;
    [SerializeField] private LayerMask bankMask;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform flyCheck;
    public float checkDistance = 2f;
    public float flycheckDistance = 2f;
    public Sprite[] colors;
    public float fallSpeed = 3f;
    public bool isFlying;
    
    public static bool canSelectBank = true;

    public Animator animator;

    private void OnMouseDown()
    {
        if (canSelectBank)
        {
            Ball ball = FindObjectOfType<Ball>();
            if(ball != null)
                ball.MoveBall(this);
        }
    }

    private void Update()
    {
        Collider2D[] banks = Physics2D.OverlapCircleAll(flyCheck.position, flycheckDistance, groundMask);
        isFlying = banks.Length > 1 ? false : true;

        if (isFlying)
        {
            transform.Translate(Vector3.down * Time.deltaTime * fallSpeed);
        }
    }

    public void ChangeColor()
    {
        int rand = Random.Range(0, colors.Length - 1);
        currentColor = colors[rand].name;
        GetComponent<SpriteRenderer>().sprite = colors[rand];
        animator.SetTrigger($"{currentColor}");
    }
    
    public void Broken()
    {
        Collider2D[] hitBanks = Physics2D.OverlapCircleAll(transform.position, checkDistance, bankMask);
        foreach (Collider2D bank in hitBanks)
        {
            if (bank.GetComponent<Bank>().currentColor == currentColor)
            {
                bank.GetComponent<Bank>().animator.SetBool("IsBroken", true);
                bank.GetComponent<Bank>().Hide();
                FindObjectOfType<Score>().IncreaseScore();
            }
        }
        Debug.Log("Broken" + currentColor);
    }


    private void Hide()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
}
