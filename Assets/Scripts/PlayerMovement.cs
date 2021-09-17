using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocity = 5f;
    private Vector2 currentVelocity;
    private Animator playerAnimator;
    private SpriteRenderer playerSpriteRenderer;
    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentVelocity = new Vector2(Input.GetAxis("Horizontal") * velocity * Time.deltaTime, 0f);
        transform.Translate(currentVelocity);

        playerAnimator.SetFloat("xVelocity", Mathf.Abs(currentVelocity.x));

        if (currentVelocity.x > 0f && !isFacingRight)
        {
            FlipPlayer();
        }
        else if (currentVelocity.x < 0f && isFacingRight)
        {
            FlipPlayer();
        }
    }

    private void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        playerSpriteRenderer.flipX = !isFacingRight;
    }
}
