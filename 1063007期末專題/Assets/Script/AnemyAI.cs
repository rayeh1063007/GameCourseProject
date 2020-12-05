using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnemyAI : MonoBehaviour
{
    public GameObject AnemyObject;
    public Animator AnemyAnimator;
    public CharacterController AnemyChar;
    public Vector3 gravity;
    public GameObject Player;
    public Collider DeadCollider;
    public float distance;
    public float Attack_Dis;
    public float Track_Dis;
    public bool Dead;
    public Collider RightHand;
    public Collider Kick;
    public GameManager gameManager;
    public enum AnemyState
    {
        Idle,
        Run,
        Attack,
        Dead
    }
    public AnemyState anemyState = AnemyState.Idle;
    // Start is called before the first frame update
    void Start()
    {
        AnemyChar = AnemyObject.GetComponent<CharacterController>();
        AnemyAnimator = AnemyObject.GetComponent<Animator>();
        Dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (AnemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            {
                AnemyAnimator.SetBool("End", true);
                AnemyChar.enabled = false;
                DeadCollider.enabled = true;
            }
        if(gameManager.Game_Start)
        {
            
            if (!Dead)
            {
                AnemyObject.transform.LookAt(Player.transform);
                distance = (Player.transform.position - AnemyObject.transform.position).magnitude;
                if (distance < Attack_Dis && anemyState != AnemyState.Attack)
                {
                    AnemyObject.transform.LookAt(Player.transform);
                    anemyState = AnemyState.Attack;
                    AnemyAnimator.SetFloat("Run", 0.0f);
                    AnemyAnimator.SetTrigger("Attack");
                }
                else if (distance < Track_Dis && distance > Attack_Dis && AnemyChar.isGrounded)
                {
                    anemyState = AnemyState.Run;
                    AnemyObject.transform.LookAt(Player.transform);
                    AnemyAnimator.SetFloat("Run", 1.0f);
                }
                if (!AnemyChar.isGrounded && anemyState != AnemyState.Attack && anemyState != AnemyState.Run)
                {
                    //anemyState = AnemyState.Idle;
                    AnemyChar.Move(gravity);
                }
                if (AnemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    anemyState = AnemyState.Idle;
                }
            }
        }
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        GameObject hitObject = hit.collider.gameObject;
        if(hitObject.tag!="Terrain")
        {
            print(hitObject.tag);
            if(hitObject.tag == "PlayerAttack" && !Dead)
            {
                Dead = true;
                anemyState = AnemyState.Dead;
                AnemyAnimator.SetBool("Dead", true);
                gameManager.Anemy_Kill();
            }
        }
        
    }
}
