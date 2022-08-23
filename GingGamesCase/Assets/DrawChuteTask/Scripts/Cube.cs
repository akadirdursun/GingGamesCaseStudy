using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abdulkadir.Drawing3DWithCube
{
    public class Cube : MonoBehaviour
    {
        public void Initialize(Vector3 postiion, Vector3 direction, float size)
        {
            transform.localPosition = postiion;

            Vector3 localScale = transform.localScale;
            localScale.z = size;
            transform.localScale = localScale;

            transform.forward = direction;
        }
    }
}