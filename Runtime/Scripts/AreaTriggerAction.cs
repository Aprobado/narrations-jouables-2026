using UnityEngine;
using UnityEngine.Events;

namespace NarrationsJouables
{
    public class AreaTriggerAction : MonoBehaviour
    {
        [Header("Filter with a tag. Leave empty for no filter")] [SerializeField]
        private string validTag = "Player";

        [Header("Actions when a body enters the area")] [SerializeField]
        private UnityEvent<Collider> TriggerEnterAction;

        [Header("Actions when a body exits the area")] [SerializeField]
        private UnityEvent<Collider> TriggerExitAction;

        private void OnTriggerEnter(Collider other)
        {
            // check if we want to filter with a tag
            if (!string.IsNullOrWhiteSpace(validTag))
            {
                // if collider coming in doesn't have the right tag, stop the method early
                if (!other.CompareTag(validTag)) return;
            }

            // call all actions that have been set in inspector
            TriggerEnterAction?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            // check if we want to filter with a tag
            if (!string.IsNullOrWhiteSpace(validTag))
            {
                // if collider coming in doesn't have the right tag, stop the method early
                if (!other.CompareTag(validTag)) return;
            }

            // call all actions that have been set in inspector
            TriggerExitAction?.Invoke(other);
        }
    }
}