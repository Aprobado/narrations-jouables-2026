using UnityEngine;

namespace NarrationsJouables
{
    public class StartDeactivated : MonoBehaviour
    {
        void Start()
        {
            gameObject.SetActive(false);
        }
    }
}