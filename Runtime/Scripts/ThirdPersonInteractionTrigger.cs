using UnityEngine;

namespace NarrationsJouables
{
    public class ThirdPersonInteractionTrigger : MonoBehaviour
    {
        private IObservable currentInteractable;
        private BoxCollider boxCollider;
        private Collider[] results;

        private void Awake()
        {
            boxCollider = GetComponent<BoxCollider>();
            results = new Collider[10];
        }

        void Update()
        {
            var hitCount = Physics.OverlapBoxNonAlloc(boxCollider.transform.position, boxCollider.size / 2f, results,
                boxCollider.transform.rotation);

            if (hitCount <= 0)
            {
                if (currentInteractable != null)
                {
                    currentInteractable.ObservationStateChanged(false);
                    currentInteractable = null;
                }

                return;
            }

            if (ResultsContainCurrentInteractable(hitCount)) return;

            currentInteractable?.ObservationStateChanged(false);
            currentInteractable = null;

            // look for a new interactable
            for (var i = 0; i < hitCount; i++)
            {
                var interactable = results[i].GetComponent<IObservable>();
                if (interactable != null)
                {
                    currentInteractable = interactable;
                    currentInteractable.ObservationStateChanged(true);
                    break;
                }
            }
        }

        private bool ResultsContainCurrentInteractable(int resultCount)
        {
            if (currentInteractable == null) return false;
            for (var i = 0; i < resultCount; i++)
            {
                var interactable = results[i].GetComponent<IObservable>();
                if (interactable == null) continue;
                if (interactable == currentInteractable) return true;
            }

            return false;
        }
    }
}