using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class CharacterMovement : MonoBehaviour
{
    //public CharacterController2D controller;

    public Check check;
    public Camera mainCamera;
    public Status player_status;
    Rigidbody2D r2d;
    Vector3 cameraPos;
    private Animator animator;
    private InputManager input;
    private InputAction movement;
    private float cooldown;
    private Vector3 scaleChange;
    bool is_attack = false;
    bool is_run = false;
    bool is_jump = false;
    float jump_start = 0;
    Vector2 move_direction = Vector2.zero;



    private void Awake()
    {
        input = new InputManager();
        input.Player.Enable();
        movement = input.Player.Movement;
        input.Player.Run.performed += Run_performed;
        input.Player.Slash.performed += Slash_performed;
        scaleChange = transform.localScale;
    }

    private void Start()
    {
        movement.performed += Movement_performed;
        animator = GetComponent<Animator>();
        r2d = GetComponent<Rigidbody2D>();
        r2d.freezeRotation = true;

        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }

        move_direction = movement.ReadValue<Vector2>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.localScale = scaleChange;
        if (is_attack && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            is_attack = false;
            animator.SetBool("Slash", false);
        }

        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, cameraPos.z);
        }

        Vector2 position = r2d.position;
        position.x = 5f * move_direction.x;
        position.y = 5f * move_direction.y;
        r2d.velocity = position;
    }

    private void Movement_performed(InputAction.CallbackContext obj)
    {
        
        move_direction = obj.ReadValue<Vector2>();
        float speed = 0f;
        is_jump = false;
        //float dying = 0f;

        
        if (move_direction.x < 0)
        {
            speed = 1f;
            scaleChange.x = -scaleChange.y;
        }
        else if (move_direction.x > 0)
        {
            speed = 1f;
            scaleChange.x = scaleChange.y;
        }

        if (move_direction.y > 0 && check.isGround)
        {
            check.isGround = false;
        }
        else if (move_direction.y < 0)
        {
            //dying = move_direction.y;
            move_direction.y = 0;
        }
        else move_direction.y = 0;

        //if (!is_jump && move_direction.y != 0)
        //{
        //    is_jump = true;
        //    jump_start = (float)obj.startTime;
        //}
        //if (move_direction.y == 0)
        //{
        //    is_jump = false;
        //    jump_start = 0f;
        //}

        animator.SetFloat("Speed", speed);
        animator.SetFloat("Jump", move_direction.y);
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Slash.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Slash.Disable();
    }

    private void Run_performed(InputAction.CallbackContext obj)
    {
        animator.Play("Running");
        Debug.Log(obj);
        //Debug.Log(obj.ReadValue<int>());
        

    }

    private void Slash_performed(InputAction.CallbackContext obj)
    {
        if (!is_attack)
        {
            animator.SetTrigger("Slash");
            StartCoroutine(InitialiseAttack());
        }
    }   

    IEnumerator InitialiseAttack()
    {
        yield return new WaitForSeconds(0.1f);
        is_attack = true;
    }
}
