using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region SerializeFields
    [SerializeField] float MoveSpeed;
    [SerializeField] float JumpSpeed;

    [SerializeField] Transform raycastingPoint;
    [SerializeField] float rayLength;

    [SerializeField] GameObject GFX;
    [SerializeField] Animator animator;

    [SerializeField] PlayerAudioPlayer audioPlayer;
    [SerializeField] GameObject collectedSoundPrefab;
    #endregion

    #region PrivateVariables

    PlayerInput input;
    private bool OnGround;
    
    Rigidbody2D MyRigidbody;

    int CoinsCollected = 0;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
        MyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatePlayer();
        FlipSprite();

        CheckGround();
        Jump();
    }

    private void FixedUpdate()
    {
        MoveHorizontal();
    }
    private void FlipSprite()
    {
        bool IfPlayerHasHorizontalSpeed = Mathf.Abs(MyRigidbody.velocity.x) > Mathf.Epsilon;

        if (IfPlayerHasHorizontalSpeed)
        {
            GFX.transform.localScale = new Vector2(Mathf.Sign(MyRigidbody.velocity.x), 1f);
        }
    }

    //basic Movement
    private void MoveHorizontal() 
    {
        float controlThrow = input.GetHorizaontalInput() * MoveSpeed * 5 * Time.deltaTime;

        Vector2 PlayerVelocity = new Vector2(controlThrow, MyRigidbody.velocity.y);
        MyRigidbody.velocity = PlayerVelocity;
    }

    private void CheckGround()
    {

        if (Physics2D.Raycast(raycastingPoint.position, Vector2.down, rayLength, LayerMask.GetMask("Ground")))
        {
            OnGround = true;
        }
        else
        {
            OnGround = false;
        }
    }
    public void Jump()
    {
        if (!OnGround || !input.JumpDown())
        { return; }

        audioPlayer.playSound(0);

        Vector2 JumpVelocity = new Vector2(0f, JumpSpeed);
        MyRigidbody.velocity += JumpVelocity;
    }



    //Coins related stuff
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            incrementCoins();
            Instantiate(collectedSoundPrefab, Vector3.zero, Quaternion.identity);

        }

        if(collision.gameObject.CompareTag("Portal"))
        {
            Destroy(collision);
            Win();
        }
    }

    private void incrementCoins()
    {
        CoinsCollected++;
        GameUI.instance.UpdateCoinsText(CoinsCollected);
    }


    //Death related Stuff
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Spikes"))
        {
            Die();
        }
    }
    private void Die()
    {
        GameUI.instance.OnDeathPannel(CoinsCollected);

        audioPlayer.playSound(1);
    }

    //Win Stuff
    private void Win()
    {
        PlayerPrefs.SetInt("LevelNumber", PlayerPrefs.GetInt("LevelNumber") + 1);

        audioPlayer.playSound(2);
        GameUI.instance.WinPannelOn(CoinsCollected);
    }

    //Animate Player
    private void AnimatePlayer()
    {
        if(MyRigidbody.velocity.x > 0.1f || MyRigidbody.velocity.x < -0.1f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if(!OnGround)
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }
}
