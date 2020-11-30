using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {

        public float movement_speed = 10f;
        public float mouse_sensitivity = 3f;


        Rigidbody rigit_body;

        PlayerMotor player_motor_script;
        

        void Start()
        {
            player_motor_script = GetComponent<PlayerMotor>();
            rigit_body = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // move the player
            Vector3 velocity = new Vector3(moveHorizontal, 0f, moveVertical) * movement_speed + new Vector3(0, rigit_body.velocity.y, 0);
            player_motor_script.Move(velocity);

            // rotate the player
            player_motor_script.Rotate(Input.mousePosition);
        }
    }
}