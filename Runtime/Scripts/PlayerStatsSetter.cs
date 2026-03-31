using StarterAssets;
using UnityEngine;

namespace NarrationsJouables
{
    public class PlayerStatsSetter : MonoBehaviour
    {
        private FirstPersonController firstPersonController;
        private FirstPersonController FirstPersonController
        {
            get
            {
                if (firstPersonController == null)
                    firstPersonController = FindFirstObjectByType<FirstPersonController>(FindObjectsInactive.Include);
                return firstPersonController;
            }
        }
        
        private ThirdPersonController thirdPersonController;
        private ThirdPersonController ThirdPersonController
        {
            get
            {
                if (thirdPersonController == null)
                    thirdPersonController = FindFirstObjectByType<ThirdPersonController>(FindObjectsInactive.Include);
                return thirdPersonController;
            }
        }

        public void SetJumpHeight(float jumpHeight)
        {
            if (FirstPersonController != null) FirstPersonController.JumpHeight = jumpHeight;
            if (ThirdPersonController != null) ThirdPersonController.JumpHeight = jumpHeight;
        }

        public void SetMoveSpeed(float moveSpeed)
        {
            if (FirstPersonController != null) FirstPersonController.MoveSpeed = moveSpeed;
            if (ThirdPersonController != null) ThirdPersonController.MoveSpeed = moveSpeed;
        }
        
        public void SetSprintSpeed(float sprintSpeed)
        {
            if (FirstPersonController != null) FirstPersonController.SprintSpeed = sprintSpeed;
            if (ThirdPersonController != null) ThirdPersonController.SprintSpeed = sprintSpeed;
        }
    }
}