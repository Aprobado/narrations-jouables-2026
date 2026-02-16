using StarterAssets;
using UnityEngine;

namespace NarrationsJouables
{
    public class PlayerStatsSetter : MonoBehaviour
    {
        private FirstPersonController controller;

        private FirstPersonController Controller
        {
            get
            {
                if (controller == null) controller = FindFirstObjectByType<FirstPersonController>();
                return controller;
            }
        }

        public void SetJumpHeight(float jumpHeight)
        {
            if (Controller != null) Controller.JumpHeight = jumpHeight;
        }

        public void SetMoveSpeed(float moveSpeed)
        {
            if (Controller != null) Controller.MoveSpeed = moveSpeed;
        }
    }
}