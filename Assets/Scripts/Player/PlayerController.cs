using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {

        public float movement_speed = 10f;


        PlayerMotor player_motor_script;
        

        void Start()
        {
            player_motor_script = GetComponent<PlayerMotor>();
        }

        void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // move the player
            Vector3 velocity = new Vector3(moveHorizontal, 0f, moveVertical) * movement_speed;
            player_motor_script.Move(velocity);

            // rotate the player
            player_motor_script.Rotate(Input.mousePosition);
        }
    }
}