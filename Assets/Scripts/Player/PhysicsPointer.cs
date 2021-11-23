using UnityEngine;

public class PhysicsPointer : Pointer
{
    [SerializeField] private LayerMask raycastMask;
    [SerializeField] private LayerMask maskToChangeColor;
    [SerializeField] private Gradient changeColorGradient;
    private Gradient originalGradient;

    private void Start()
    {
        originalGradient = lineRenderer.colorGradient;
    }

    protected override Vector3 GetEnd()
    {
        RaycastHit hit = CreateForwardRayCast();
        Vector3 endPosition = CalculateEnd(defaultLength);

        if (hit.collider)
            endPosition = hit.point;

        return endPosition;
    }

    private RaycastHit CreateForwardRayCast()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, raycastMask) && (1 << hit.collider.gameObject.layer & maskToChangeColor.value) != 0)
        {
            lineRenderer.colorGradient = changeColorGradient;
        }
        else
        {
            lineRenderer.colorGradient = originalGradient;
        }
        return hit;
    }
}
