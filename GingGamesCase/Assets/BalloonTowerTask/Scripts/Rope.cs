using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.BalloonTower
{
    public class Rope : MonoBehaviour
    {
        [SerializeField] private Transform ropePosition;
        private LineRenderer lineRenderer;

        #region MonoBehaviour METHODS
        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        private void Start()
        {
            lineRenderer.SetPosition(0, transform.position);
        }

        private void FixedUpdate()
        {
            lineRenderer.SetPosition(1, ropePosition.position);
        }
        #endregion
    }
}