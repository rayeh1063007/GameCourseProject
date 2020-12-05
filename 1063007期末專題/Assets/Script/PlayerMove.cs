using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject PlayerObject;
    public Animator PlayerAnimator;
    public float input_V;
    public float input_H;
    public float RotateSpeed=3;
    public CharacterController PlayerChar;
    public Vector3 gravity;
    public Collider Attack1_Collider;
    public GameManager gameManager;
    public enum PlayerState
    {
        Idle,
        Run,
        Attack_1,
    }
    private PlayerState playerState = PlayerState.Idle;
    // Start is called before the first frame update
    void Start()
    {
        PlayerChar = PlayerObject.GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        if(gameManager.Game_Start)
        {
            input_V = Input.GetAxis("Vertical"); //垂直
            input_H = Input.GetAxis("Horizontal"); //水平

            if (input_V != 0)
            {
                playerState = PlayerState.Run;
                PlayerAnimator.SetBool("Move", true);
                PlayerObject.transform.Translate(1, 0, 0);
            }
            else
            {
                PlayerAnimator.SetBool("Move", false);
            }
            PlayerAnimator.SetFloat("Run", input_V);

            if (playerState != PlayerState.Attack_1)
            {
                if (input_H > 0)
                {
                    PlayerObject.transform.Rotate(0, RotateSpeed , 0);
                }
                else if (input_H < 0)
                {
                    PlayerObject.transform.Rotate(0, -RotateSpeed , 0);
                }
            }

            if (!PlayerChar.isGrounded)
            {
                PlayerChar.Move(gravity);
            }

            if (Input.GetMouseButton(0))
            {
                PlayerAnimator.SetBool("Attack1", true);
                playerState = PlayerState.Attack_1;
            }
            if (Input.GetMouseButtonUp(0))
            {
                PlayerAnimator.SetBool("Attack1", false);
            }
            if (PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("standing idle"))
            {
                playerState = PlayerState.Idle;
            }
            if (PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("attack horizontal"))
            {
                Attack1_Collider.enabled = true;
            }
            else
            {
                Attack1_Collider.enabled = false;
            }
        }

    }
}
