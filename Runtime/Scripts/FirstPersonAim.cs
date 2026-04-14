using UnityEngine;

namespace NarrationsJouables
{
    public class FirstPersonAim : MonoBehaviour
    {
        private Camera cam;
        private Ray ray;
        private RaycastHit[] hits;
        private RaycastHit closestHit;
        private IObservable currentInteractable;

        void Awake()
        {
            cam = GetComponent<Camera>();
            ray = new Ray();
            hits = new RaycastHit[20]; // we only query for one hit, but use an array to avoid memory allocation
        }

        void Update()
        {
            ray.origin = cam.transform.position;
            ray.direction = cam.transform.forward;
            var hitCount = Physics.RaycastNonAlloc(ray, hits);
            if (hitCount > 0)
            {
                // Always use the closest element we hit. The raycast result is not sorted.
                closestHit = hits[0];
                for (var i = 1; i < hitCount; i++)
                {
                    if (hits[i].distance < closestHit.distance) closestHit = hits[i];
                }

                var interactable = closestHit.transform.GetComponent<IObservable>();

                // when interactable changed
                if (currentInteractable != interactable)
                {
                    // if there was a valid interactable previously, tell it the interaction ended
                    if (currentInteractable != null) currentInteractable.ObservationStateChanged(false);
                    // change the reference to the new interactable (can be null)
                    currentInteractable = interactable;
                }

                // if the current interactable exists, send an update with current distance
                if (interactable != null) interactable.ObservationStateChanged(true, closestHit.distance);

                Debug.DrawRay(ray.origin, ray.direction * closestHit.distance, Color.yellow);
            }
            // if we didn't hit anything, stop the active interaction
            else if (currentInteractable != null)
            {
                currentInteractable.ObservationStateChanged(false);
                currentInteractable = null;
            }
        }
    }
}