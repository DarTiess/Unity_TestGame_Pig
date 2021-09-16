using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    public FixedJoystick Joystick;
 
    public float speed;
    private bool isTurnRight = true;
    private bool isTurnUp = true;
    public Sprite spriteForward;
    public Sprite spriteUp;
    public Sprite spriteDown;
    public SpriteRenderer spriteRenderer;
    bool canMove=true;
    Vector2 startPosition;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
       
    }
    void Move()
    {
       

        float moveForward = Joystick.inputVector.x;
        float moveUp = Joystick.inputVector.y;
       
       
       if (moveUp >= 0.9f || moveUp <= -0.9f)
        {
           // spriteRenderer.sprite = spriteUp;
            transform.Translate(Vector3.up * moveUp * speed * Time.deltaTime);
            if (moveUp > 0 )
            {
                spriteRenderer.sprite = spriteUp;

            }
            else if (moveUp < 0 )
            {

                spriteRenderer.sprite = spriteDown;

            }
        }else
        {
            if (moveForward != 0)
            {
                spriteRenderer.sprite = spriteForward;
                transform.Translate(Vector3.right * moveForward * speed * Time.deltaTime);
                if (moveForward > 0 && !isTurnRight)
                {
                    TurnRight();

                }
                else if (moveForward < 0 && isTurnRight)
                {

                    TurnRight();

                }
            }
        }
       
    }

    void TurnRight()
    {
        isTurnRight = !isTurnRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;
        transform.localScale = theScale;
    } 
    
    void TurnUp()
    {
        isTurnUp = !isTurnUp;

        Vector3 theScale = transform.localScale;

        theScale.y *= -1;
        transform.localScale = theScale;
    }
     public void DeathPig()
    {
        canMove = false;
        spriteRenderer.sprite = spriteForward;
        transform.rotation = Quaternion.Euler(0, 0, -90f);
        StartCoroutine(FailedGame());
       
    }

    IEnumerator FailedGame()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.FailGame();
    }
 
    public void RestartPiggie()
    {
        canMove = true;
        spriteRenderer.sprite = spriteForward;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = startPosition;
    }
   

   
}
