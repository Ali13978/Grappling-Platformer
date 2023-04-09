using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class GenerateCollissions : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    public void Generate()
    {
        Vector2[] localPositions = new Vector2[lineRenderer.positionCount];

        // Convert the line renderer's positions to local space
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            localPositions[i] = transform.InverseTransformPoint(lineRenderer.GetPosition(i));
        }

        // Set the edge collider's points to the local positions
        edgeCollider.points = localPositions;
    }
}