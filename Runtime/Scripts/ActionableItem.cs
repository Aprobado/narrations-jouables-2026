using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace NarrationsJouables
{
    public class ActionableItem : MonoBehaviour, IObservable
    {
        [SerializeField] private UnityEvent OnInteract;
        [SerializeField] private UnityEvent OnInteractionDelayEnds;
        [SerializeField] private float delayBetweenInteractions = 1f;
        [SerializeField] private GameObject highlight;
        [SerializeField] private bool useMinMax = true;
        [SerializeField] private float minDistance = 0f;
        [SerializeField] private float maxDistance = 3f;

        private bool actionable;
        private float lastUse;
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
                if (lastUse + delayBetweenInteractions > Time.realtimeSinceStartup) return;
                if (PlayerControlPauseHandler != null && !PlayerControlPauseHandler.playerControlIsOn) return;
                OnInteract?.Invoke();
                lastUse = Time.realtimeSinceStartup;

                if (gameObject.activeInHierarchy)
                {
                    if (delayBetweenInteractions <= 0) OnInteractionDelayEnds?.Invoke();
                    else StartCoroutine(InteractionDelayEnds());
                }
            }
        }

        IEnumerator InteractionDelayEnds()
        {
            yield return new WaitForSeconds(delayBetweenInteractions - 0.01f);
            OnInteractionDelayEnds?.Invoke();
        }

        public bool ObservationStateChanged(bool _observed, float _distance = -1)
        {
            var valid = !useMinMax || _distance > minDistance && _distance < maxDistance;
            var coolingDown = lastUse + delayBetweenInteractions > Time.realtimeSinceStartup;
            actionable = _observed && valid && !coolingDown;
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