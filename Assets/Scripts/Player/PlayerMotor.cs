using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    class PlayerMotor : MonoBehaviour
    {

        Vector3 velocity = Vector3.zero;
        Vector3 rotation = Vector3.zero;

        Rigidbody rigid_body;

        // scripts
        PlayerAnimator playerAnimator;

        void Start()
        {
            rigid_body = GetComponent<Rigidbody>();
            playerAnimator = GetComponent<PlayerAnimator>();
        }

        void FixedUpdate()
        {
            MovePlayer();
            RotatePlayer();
        }

        // function to perform the movement of the player
        void MovePlayer()
        {
            if (velocity != Vector3.zero)
            {
                rigid_body.MovePosition(rigid_body.position + velocity * Time.fixedDeltaTime);
                // TODO - quick test
                playerAnimator.ChangeState(PlayerState.MOVING_FORWARD);
            }
            else
            {
                playerAnimator.ChangeState(PlayerState.IDLE);
            }
        }

        // function to perform the rotation of the player
        void RotatePlayer()
        {
            Vector3 mouse_position = rotation;

            Vector3 object_position = Camera.main.WorldToScreenPoint(transform.position);

            mouse_position.x -= object_position.x;
            mouse_position.y -= object_position.y;

            float angle = Mathf.Atan2(mouse_position.y, mouse_position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
        }

        public void Move(Vector3 _velocity)
        {
            velocity = _velocity;
        }

        public void Rotate(Vector3 _rotation)
        {
            rotation = _rotation;
        }

    }
}
