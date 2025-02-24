using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Knockback : MonoBehaviour
{
    [SerializeField] float strength = 10, delay = 0.15f;

    [SerializeField] private Rigidbody2D rb;

    public UnityEvent onBegin, onEnd;

    public void PlayKnockback(GameObject sender)
    {
        StopAllCoroutines();

        onBegin?.Invoke();

        Vector3 dir = (transform.position - sender.transform.position).normalized;
        dir.y = 0f;
        rb.AddForce(dir * strength, ForceMode2D.Impulse);

        StartCoroutine(ResetKnockback());
    }

    public void PlayKnockbackWithForce(GameObject sender, float force)
    {
        StopAllCoroutines();

        onBegin?.Invoke();

        rb.velocity = Vector3.zero;
        Vector3 dir = (transform.position - sender.transform.position).normalized;
        dir.z = 0f;
        rb.AddForce(dir * force, ForceMode2D.Impulse);

        StartCoroutine(ResetKnockback());
    }

    private IEnumerator ResetKnockback()
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector3.zero;
        onEnd?.Invoke();
    }
}
