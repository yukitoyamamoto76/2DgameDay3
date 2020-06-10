using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public GameObject gameManager;

    public LayerMask blockLayer;
    private Rigidbody2D rbody;
    private Animator animator;

    private const float MOVE_SPEED = 2;
    private float moveSpeed;

    private float jumpPower = 400;
    private bool goJump = false;
    private bool canJump = false;
    private bool usingButtons = false;

    public enum MOVE_DIR
    {
        STOP,
        LEFT,
        RIGHT
    };
    private MOVE_DIR moveDirection = MOVE_DIR.STOP;

    public AudioClip getSE;
    private AudioSourceController audioSource;

    // Use this for initialization
    void Start () {
        audioSource = gameManager.GetComponent<AudioSource>();
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update () 
    {
        canJump = true;
        animator.SetBool("onGrand", canJump);
        if (!usingButtons)
        {
            float x = Input.GetAxisRow("Horizontal");
        } 
    // var h = Input.GetAxis("Horizontal");
    var v = Input.GetAxis("Vertical");

        if (goJump)
        {
            rbody.AddForce(Vector2.up * jumpPower);
            goJump = false;
        }
    // 移動する向きを作成する
    // Vector2 direction = new Vector2(h, v).normalized;

    // 移動する向きとスピードを代入 
    // GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
    public void PushLeftButton()
    {
        moveDirection = MOVE_DIR.LEFT;
        usingButtons = true;
    }
    public void PushRightButton()
    {
        moveDirection = MOVE_DIR.RIGHT;
        usingButtons = true;
    }
}
