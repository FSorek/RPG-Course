using UnityEngine;

public class ItemRaycaster : ItemComponent
{
    [SerializeField] private float delay = .1f;
    [SerializeField] private float range = 10f;
    [SerializeField]private int damage = 1;

    private RaycastHit[] results = new RaycastHit[10];
    private int layerMask;

    private void Awake()
    {
        layerMask = LayerMask.GetMask("Default");
    }

    public override void Use()
    {
        nextUseTime = Time.time + delay;

        Ray ray = Camera.main.ViewportPointToRay(Vector3.one / 2f);
        int hits = Physics.RaycastNonAlloc(ray, results, range, layerMask, QueryTriggerInteraction.Collide);
        
        RaycastHit nearest = new RaycastHit();
        double nearestDistance = double.MaxValue;

        for (int i = 0; i < hits; i++)
        {
            var distance = Vector3.Distance(transform.position, results[i].point);
            if (distance < nearestDistance)
            {
                nearest = results[i];
                nearestDistance = distance;
            }
        }

        if (nearest.transform != null)
        {
            var takeHits = nearest.collider.GetComponent<ITakeHits>();
            takeHits?.TakeHit(damage);
        }
    }
}