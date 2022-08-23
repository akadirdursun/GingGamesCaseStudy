using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Abdulkadir.Drawing3DWithCube
{
    public class LineController : MonoBehaviour
    {
        [SerializeField] private LayerMask drawAreaLayer;
        [SerializeField] private Camera uiCamera;
        [Space]
        [SerializeField][Range(0f, 1f)] private float drawLineFrequency = 0.1f;
        [SerializeField][Range(0f, 2f)] private float minLineDistance = 0.2f;

        private LineRenderer lineRenderer;
        private Coroutine onDrawCoroutine;

        #region MonoBehaviour METHODS
        private void Awake()
        {
            lineRenderer = GetComponentInChildren<LineRenderer>(true);
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnDrawStart();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                OnDrawEnd();
            }
        }
        #endregion

        private void OnDrawStart()
        {
            if (onDrawCoroutine != null) return;

            Vector3 mouseWorldPos = uiCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D rayHit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, 100f, drawAreaLayer);
            if (rayHit)
            {
                Vector3 linePos = rayHit.point;
                linePos.z = 10f;
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, linePos);

                lineRenderer.gameObject.SetActive(true);
                onDrawCoroutine = StartCoroutine(OnDraw());
            }
        }

        private IEnumerator OnDraw()
        {
            while (true)
            {
                yield return new WaitForSeconds(drawLineFrequency);

                Vector3 mouseWorldPos = uiCamera.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D rayHit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, 100f, drawAreaLayer);
                if (rayHit)
                {
                    Vector3 linePos = rayHit.point;
                    linePos.z = 10f;

                    if (((linePos - lineRenderer.GetPosition(lineRenderer.positionCount - 1)).magnitude) < minLineDistance) continue;

                    lineRenderer.positionCount++;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, linePos);
                }
                else
                {
                    OnDrawEnd();
                }
            }
        }

        private void OnDrawEnd()
        {
            if (onDrawCoroutine == null) return;

            StopCoroutine(onDrawCoroutine);
            onDrawCoroutine = null;

            //TODO: Draw 3D w Cubes
            Vector3[] positions = new Vector3[lineRenderer.positionCount];
            lineRenderer.GetPositions(positions);
            StaticEvents.onDrawingEnded?.Invoke(positions);

            lineRenderer.gameObject.SetActive(false);
            lineRenderer.positionCount = 0;
        }
    }
}