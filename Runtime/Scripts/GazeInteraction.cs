using UnityEngine;
using UnityEngine.Events;

namespace NarrationsJouables
{
    public class GazeInteraction : MonoBehaviour, IObservable
    {
        [SerializeField] private UnityEvent OnGazeEnter;
        [SerializeField] private UnityEvent OnGazeExit;

        [SerializeField] private GameObject highlight;
        [SerializeField] private bool useMinMax = true;
        [SerializeField] private float minDistance = 0f;
        [SerializeField] private float maxDistance = 3f;

        private bool isObserved;

        private void Start()
        {
            if (highlight != null) highlight.SetActive(false);
        }

        public bool ObservationStateChanged(bool _observed, float _distance = -1)
        {
            var valid = !useMinMax || _distance > minDistance && _distance < maxDistance;
            var state = _observed && valid;
            // if state changed
            if (isObserved != state)
            {
                isObserved = state;
                if (isObserved) OnGazeEnter?.Invoke();
                else OnGazeExit?.Invoke();
                if (highlight != null) highlight.SetActive(isObserved);
            }

            return isObserved;
        }
    }
}