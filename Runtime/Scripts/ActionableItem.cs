using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace NarrationsJouables
{
    public class ActionableItem : MonoBehaviour, IObservable
    {
        [SerializeField] private UnityEvent OnInteract;
        [SerializeField] private GameObject highlight;
        [SerializeField] private bool useMinMax = true;
        [SerializeField] private float minDistance = 0f;
        [SerializeField] private float maxDistance = 3f;

        private bool actionable;
        private InputAction interactAction;
        private PlayerControlPauseHandler playerControlPauseHandler;
        private PlayerControlPauseHandler PlayerControlPauseHandler
        {
            get
            {
                if (playerControlPauseHandler == null) playerControlPauseHandler = FindAnyObjectByType<PlayerControlPauseHandler>();
                return playerControlPauseHandler;
            }
        }

        private void Awake()
        {
            interactAction = InputSystem.actions.FindAction("Interact");
            if (interactAction == null)
            {
                Debug.LogError($"[ActionableItem] This script needs a \"Interact\" action in the input system scheme in order to work.");
            }
        }

        private void Start()
        {
            if (highlight != null) highlight.SetActive(false);
        }

        void Update()
        {
            if (interactAction != null && interactAction.WasPressedThisFrame())
            {
                if (!actionable) return;
                if (PlayerControlPauseHandler != null && !PlayerControlPauseHandler.playerControlIsOn) return;
                OnInteract?.Invoke();
            }
        }

        public bool ObservationStateChanged(bool _observed, float _distance = -1)
        {
            var valid = !useMinMax || _distance > minDistance && _distance < maxDistance;
            actionable = _observed && valid;
            if (highlight != null) highlight.SetActive(actionable);
            return actionable;
        }

        private void OnDrawGizmos()
        {
            if (!useMinMax) return;
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, maxDistance);
        }
    }
}