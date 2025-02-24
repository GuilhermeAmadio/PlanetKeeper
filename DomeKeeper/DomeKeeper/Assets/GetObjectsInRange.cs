using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObjectsInRange : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private LayerMask objectsLayer;

    [SerializeField] private List<GameObject> ignoreObjects = new List<GameObject>();

    private List<GameObject> objectsHitted = new List<GameObject>();

    public List<GameObject> GetObjects()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, range, objectsLayer);

        foreach (Collider2D obj in hitObjects)
        {
            if (!objectsHitted.Contains(obj.gameObject) && !ignoreObjects.Contains(obj.gameObject))
            {
                objectsHitted.Add(obj.gameObject);
            }
        }

        return objectsHitted;
    }

    public List<GameObject> GetSortedObjects()
    {
        List<GameObject> objects = GetObjects();

        objects.Sort((a, b) => Vector3.Distance(a.transform.position, transform.position).CompareTo(Vector3.Distance(b.transform.position, transform.position)));

        return objects;
    }

    public GameObject GetClosestObject()
    {
        GameObject closestObject = null;
        List<GameObject> objects = GetObjects();

        if (objects.Count > 0)
        {
            float closestDistance = 1000000;
            foreach (GameObject obj in objects)
            {
                if (Vector3.Distance(obj.transform.position, gameObject.transform.position) < closestDistance)
                {
                    closestObject = obj;
                    closestDistance = Vector3.Distance(obj.transform.position, closestObject.transform.position);
                }
            }
        }

        return closestObject;
    }

    private void OnEnable()
    {
        objectsHitted.Clear();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
