using System;
using UnityEngine;

public class PlayerJoystickController : MonoBehaviour
{
    
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField]private float angleSpeed;
    [SerializeField]private float speed;
    private Vector3 _direction;
    private float power = 0;
    
    private Rigidbody _rigidbody;
    private Animator _animator;

    private bool _movement = false;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    
    private void Update()
    {
        JoystickDirection();
        JoystickPower();
    }
    
    private void FixedUpdate()
    {
        CharacterMovement(_direction,power);
    }
    
    private void JoystickPower()
    {
            
        if (Input.GetMouseButton(0))
        {
            power =new Vector2(_joystick.Vertical,
                _joystick.Horizontal).magnitude; 
        }
        else
        {
            power = 0;
        }
    }

    private void JoystickDirection()
    {
        if (Input.GetMouseButton(0))
        {
            _direction = _joystick.Direction;
            _direction.z = _direction.y;
            _direction.y = 0;
        }
    }

    private void CharacterMovement(Vector3 direction,float power)
    {
        if (power<.1f)
        {
            power = 0;
        }
        else
        {
            power = 1;
        }
        
        float animPower = power;
        _animator.SetFloat("Run",animPower);
        _rigidbody.velocity = speed * Time.fixedDeltaTime * power*transform.forward;
        if (direction!=Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,transform.rotation = Quaternion.LookRotation(direction), Time.fixedDeltaTime * angleSpeed);
        }
    }
}
