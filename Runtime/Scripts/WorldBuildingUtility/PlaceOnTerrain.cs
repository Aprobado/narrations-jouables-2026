using UnityEngine;

namespace NarrationsJouables.WorldBuildingUtility
{
    // Utility script to place an object on a terrain
    public class PlaceOnTerrain : MonoBehaviour
    {
        private static RaycastHit[] results;
        [Header("Let us start the raycast way above the object.\nUseful if its starting position is under the terrain.")]
        [SerializeField] private Vector3 raycastOriginOffset = new Vector3(0, 10f, 0);
        [Header("Offset the final position if the pivot is not at the base of the object.")]
        [SerializeField] private Vector3 finalPositionOffset = Vector3.zero;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if (results == null) results = new RaycastHit[10];
            var ray = new Ray(transform.position + raycastOriginOffset, Vector3.down);
            var hitCount = Physics.RaycastNonAlloc(ray, results, 1000f);
            for (var i = 0; i < hitCount; i++)
            {
                var hit = results[i];
                if (hit.collider is TerrainCollider terrainCollider)
                {
                    transform.position = hit.point;
                }
            }
        }
    }
}
