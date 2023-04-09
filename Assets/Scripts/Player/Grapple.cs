using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public Camera cam;
    public LineRenderer bridgeLine;
    public LayerMask grappleMask;
    public float grappleLength = 5;

    private bool firstClick = true;
    private bool followPlayer = false;
    public GenerateCollissions generateCollisions;

    [SerializeField] GameObject GunHolder;
    [SerializeField] Transform Gun;
    [SerializeField] PlayerAudioPlayer audioPlayer;

    private LineRenderer lineRenderer;

    private void Start()
    {
        cam = Camera.main;

        GameObject DebugRayObject = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);
        
        lineRenderer = DebugRayObject.AddComponent<LineRenderer>();

        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - (Vector2)Gun.position).normalized;

            RaycastHit2D hit = Physics2D.Raycast(Gun.position, direction, grappleLength, grappleMask);
            if (hit.collider != null)
            {
                Vector2 hitPoint = hit.point;

                audioPlayer.playSound(3);
                if(firstClick)
                {
                    bridgeLine.SetPosition(0, Gun.position);
                    bridgeLine.SetPosition(1, hitPoint);

                    bridgeLine.GetComponent<EdgeCollider2D>().enabled = false;
                    firstClick = false;

                    followPlayer = true;                   
                }
                else
                {
                    firstClick = true;
                    followPlayer =false;
                    bridgeLine.SetPosition(0, hitPoint);

                    bridgeLine.GetComponent<EdgeCollider2D>().enabled = true;
                    generateCollisions.Generate();

                }
            }
        }

        else if(Input.GetMouseButton(1))
        {
            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

            Vector3 direction = mousePosition - Gun.position;
            direction.z = 0f;
            direction.Normalize();

            RaycastHit2D hit = Physics2D.Raycast(Gun.position, direction, grappleLength);

            lineRenderer.SetPosition(0, Gun.position);

            if (hit.collider != null)
            {
                lineRenderer.SetPosition(1, hit.point);
            }
            else
            {
                lineRenderer.SetPosition(1, Gun.position + direction * grappleLength);
            }   
        }

        else if(Input.GetMouseButtonUp(1))
        {
            lineRenderer.SetPosition(0, Vector2.zero);
            lineRenderer.SetPosition(1, Vector2.zero);
        }

        if (followPlayer)
        {
            bridgeLine.SetPosition(0, Gun.position);
        }

        CreateRayinDirectionOfMouse();
    }

    private void CreateRayinDirectionOfMouse()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePosition - transform.position;
        direction.z = 0f;
        direction.Normalize();
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        GunHolder.transform.rotation = Quaternion.Euler(0, 0, angle);

    }

}