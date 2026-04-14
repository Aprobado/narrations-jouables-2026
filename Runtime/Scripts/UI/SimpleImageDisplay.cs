using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace NarrationsJouables.UI
{
    public class SimpleImageDisplay : MonoBehaviour
    {
        [Header("The Game Menu could be a \"blocking\" canvas")]
        [SerializeField] private Canvas[] blockingCanvas;
        [SerializeField] private Image mainImage;

        private bool displayIsOn;

        private Canvas canvas;
        private InputAction inventoryAction;
        private InputAction interactAction;
        private bool itemJustDisplayed;

        void Awake()
        {
            canvas = GetComponent<Canvas>();
            inventoryAction = InputSystem.actions.FindAction("Inventory");
            interactAction = InputSystem.actions.FindAction("Interact");
            displayIsOn = false;
            canvas.enabled = displayIsOn;
        }

        private void Start()
        {
            var playerControlManager = FindAnyObjectByType<PlayerControlPauseHandler>();
            if (playerControlManager == null)
            {
                var go = new GameObject("Player Control Pause Handler");
                playerControlManager = go.AddComponent<PlayerControlPauseHandler>();
            }
            playerControlManager.AddBlockingCanvas(canvas);
        }

        void Update()
        {
            foreach (var canvas in blockingCanvas)
            {
                if (canvas.enabled && canvas.gameObject.activeInHierarchy) return;
            }

            if (itemJustDisplayed)
            {
                itemJustDisplayed = false;
                return;
            }

            if (inventoryAction.WasPressedThisFrame())
            {
                displayIsOn = !displayIsOn;
            }
            else if (interactAction.WasPressedThisFrame() && displayIsOn)
            {
                displayIsOn = !displayIsOn;
            }

            canvas.enabled = displayIsOn;
        }

        public void DisplayItem(Sprite sprite)
        {
            mainImage.sprite = sprite;
            displayIsOn = true;
            itemJustDisplayed = true;
        }
    }
}