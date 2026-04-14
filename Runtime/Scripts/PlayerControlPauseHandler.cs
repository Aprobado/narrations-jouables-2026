using System.Collections.Generic;
using System.Linq;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NarrationsJouables
{
    public class PlayerControlPauseHandler : MonoBehaviour
    {
        [SerializeField] private List<Canvas> pausingCanvases;

        public bool playerControlIsOn;

        private FirstPersonController[] firstPersonControllers;
        private ThirdPersonController[] thirdPersonControllers;
        private PlayerInput[] playerInputs;

        void Awake()
        {
            firstPersonControllers = FindObjectsByType<FirstPersonController>(FindObjectsInactive.Include);
            thirdPersonControllers = FindObjectsByType<ThirdPersonController>(FindObjectsInactive.Include);
            playerInputs = FindObjectsByType<PlayerInput>(FindObjectsInactive.Include);
        }

        private void Start()
        {
            EnablePlayerControl(true);
        }

        void Update()
        {
            // if any UI is active, disable player control
            var enable = !pausingCanvases.Any(pausingUI => pausingUI.enabled && pausingUI.gameObject.activeInHierarchy);

            if (playerControlIsOn != enable) EnablePlayerControl(enable);
        }

        private void EnablePlayerControl(bool enable)
        {
            playerControlIsOn = enable;
            foreach (var playerInput in playerInputs)
            {
                playerInput.enabled = enable;
            }

            foreach (var firstPersonController in firstPersonControllers)
            {
                firstPersonController.enabled = enable;
            }

            foreach (var thirdPersonController in thirdPersonControllers)
            {
                thirdPersonController.enabled = enable;
            }
        }

        public void AddBlockingCanvas(Canvas canvas)
        {
            if (pausingCanvases == null) pausingCanvases = new List<Canvas>();
            if (!pausingCanvases.Contains(canvas)) pausingCanvases.Add(canvas);
        }
    }
}