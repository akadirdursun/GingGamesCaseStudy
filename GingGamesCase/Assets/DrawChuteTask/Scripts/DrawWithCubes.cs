using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.Drawing3DWithCube
{
    public class DrawWithCubes : MonoBehaviour
    {
        [SerializeField] private Cube cubePrefab;

        #region MonoBehaviour METHODS
        private void OnEnable()
        {
            StaticEvents.onDrawingEnded += OnDrawLineEnded;
        }
        private void OnDisable()
        {
            StaticEvents.onDrawingEnded -= OnDrawLineEnded;
        }
        #endregion

        #region EVENT LISTENERS
        private void OnDrawLineEnded(Vector3[] positions)
        {
            ClearCubes();
            for (int i = 0; i < positions.Length - 1; i++)
            {
                Vector3 direction = positions[i + 1] - positions[i];

                Cube newCube = Instantiate(cubePrefab, transform);
                newCube.Initialize(positions[i] + (direction.magnitude / 2 * direction.normalized), direction, direction.magnitude);
            }
        }
        #endregion

        private void ClearCubes()
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}