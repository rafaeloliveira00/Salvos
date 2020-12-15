using UnityEngine;

namespace Assets.Scripts.Player
{
    public enum PlayerState
    {
        IDLE,
        MOVING_FORWARD,
        MOVING_BACKWARDS,
        MOVING_LEFT,
        MOVING_RIGTH,
        DEAD
    };

    static class PlayerStateDefenition
    {
        // the string values must be the same as the animator values
        public const string IDLE = "idle";
        public const string MOVING_FORWARD = "forward";
        public const string MOVING_BACKWARDS = "backward";
        public const string MOVING_LEFT = "left";
        public const string MOVING_RIGTH = "rigth";
        public const string DEAD = "dead";

        public static string convertState(PlayerState state)
        {
            switch (state)
            {
                case PlayerState.IDLE:
                    return PlayerStateDefenition.IDLE;
                case PlayerState.MOVING_FORWARD:
                    return PlayerStateDefenition.MOVING_FORWARD;
                case PlayerState.MOVING_LEFT:
                    return PlayerStateDefenition.MOVING_LEFT;
                case PlayerState.MOVING_RIGTH:
                    return PlayerStateDefenition.MOVING_RIGTH;
                case PlayerState.MOVING_BACKWARDS:
                    return PlayerStateDefenition.MOVING_BACKWARDS;
                case PlayerState.DEAD:
                    return PlayerStateDefenition.DEAD;
                default:
                    return PlayerStateDefenition.IDLE;
            }
        }
    }

    public class PlayerAnimator : MonoBehaviour
    {
        public Animator animator;

        string current_trigger = PlayerStateDefenition.IDLE;

        public void ChangeState(PlayerState state)
        {
            string trigger = PlayerStateDefenition.convertState(state);

            // reset the last trigger before activating a new one
            animator.ResetTrigger(current_trigger);

            current_trigger = trigger;
            animator.SetTrigger(trigger);
        }
    }
}