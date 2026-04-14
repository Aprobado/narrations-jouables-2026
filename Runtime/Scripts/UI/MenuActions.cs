#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NarrationsJouables.UI
{
    public class MenuActions : MonoBehaviour
    {
        [SerializeField] private Selectable firstSelected;
        public bool menuIsOn = false;
        public bool isGamepad = false;

        private Canvas canvas;
        private InputAction menuAction;
        private InputAction navigateAction;

        private void Awake()
        {
            canvas = GetComponent<Canvas>();
        }

        private void Start()
        {
            menuIsOn = false;
            UpdateMenuState();
            menuAction = InputSystem.actions.FindAction("Menu");
			if (menuAction == null)
            {
				Debug.LogError($"[MenuActions] This script needs a \"Menu\" action in the input system scheme in order to work.");
			}
            navigateAction = InputSystem.actions.FindAction("Navigate");
            
            var playerControlManager = FindAnyObjectByType<PlayerControlPauseHandler>();
            if (playerControlManager == null)
            {
                var go = new GameObject("Player Control Pause Handler");
                playerControlManager = go.AddComponent<PlayerControlPauseHandler>();
            }
            playerControlManager.AddBlockingCanvas(canvas);
        }

        private void Update()
        {
            var newIsGamepad = isGamepad;
            var newMenuIsOn = menuIsOn;
            if (Mouse.current.delta.magnitude > 0.1f)
            {
                if (isGamepad) newIsGamepad = false;
            }

            if (navigateAction != null)
            {
                if (navigateAction.WasPressedThisFrame())
                {
                    newIsGamepad = navigateAction.activeControl.device.name != "Keyboard";
                }
            }

            if (menuAction != null)
            {
                if (menuAction.WasPressedThisFrame())
                {
                    newIsGamepad = menuAction.activeControl.device.name != "Keyboard";
                    newMenuIsOn = !menuIsOn;
                }
            }

            if (isGamepad != newIsGamepad || menuIsOn != newMenuIsOn)
            {
                isGamepad = newIsGamepad;
                menuIsOn = newMenuIsOn;
                // do the input change
                UpdateMenuState();
            }
        }

        private void UpdateMenuState()
        {
            canvas.enabled = menuIsOn;
            Cursor.visible = menuIsOn;
            Cursor.lockState = menuIsOn && !isGamepad ? CursorLockMode.None : CursorLockMode.Locked;

            if (isGamepad && !EventSystem.current.alreadySelecting) firstSelected.Select();
            if (!isGamepad) EventSystem.current.SetSelectedGameObject(null);
        }

        public void Continue()
        {
            if (!canvas.enabled) return;
            menuIsOn = false;
            UpdateMenuState();
        }

        public void RestartScene()
        {
            if (!canvas.enabled) return;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Quit()
        {
            if (!canvas.enabled) return;
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}