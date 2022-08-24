using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.BalloonTower
{
    public class BalloonSpawner : MonoBehaviour
    {
        [SerializeField] private Balloon balloonPrefab;

        private Rigidbody myRigidbody;

        #region MonoBehaviour METHODS
        private void Awake()
        {
            myRigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SpawnBalloon();
            }
        }
        #endregion

        private void SpawnBalloon()
        {
            if (balloonPrefab == null) return;

            Balloon newBalloon = Instantiate(balloonPrefab, transform);
            newBalloon.Initialize(myRigidbody);
        }
    }
}