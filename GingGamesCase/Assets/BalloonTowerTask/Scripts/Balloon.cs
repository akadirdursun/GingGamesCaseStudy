using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Abdulkadir.BalloonTower
{
    public class Balloon : MonoBehaviour
    {
        [SerializeField] private List<Material> materials = new List<Material>();

        private void SetMaterial()
        {
            int randomIndex = Random.Range(0, materials.Count);

            GetComponentInChildren<MeshRenderer>().material = materials[randomIndex];
        }

        public void Initialize(Rigidbody playerRB)
        {
            SetMaterial();

            Vector2 randomPos = (Random.insideUnitCircle * 0.25f);
            transform.localPosition = new Vector3(randomPos.x, 0f, randomPos.y);

            GetComponent<SpringJoint>().connectedBody = playerRB;
            transform.DOScale(1f, 1.5f);
        }
    }
}