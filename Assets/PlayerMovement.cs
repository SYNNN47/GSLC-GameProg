using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Animator animator;
    Vector2 movement;

    private int itemCounter = 0;
    public TMP_Text counterText;
    private string Scene2;
    



    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item") && collision.gameObject.activeSelf)
        {
            collision.gameObject.SetActive(false);
            itemCounter += 1;
            counterText.text = "Items: " + itemCounter;

            if(itemCounter >= 10)
            {
                SceneManager.LoadScene("Scene2");

            }
        }
    }

    


}
