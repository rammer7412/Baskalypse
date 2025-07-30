using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Animator animator;
    private Collider2D blockColider;

    private void Start()
    {
        animator = GetComponent<Animator>();
        blockColider = GetComponent<Collider2D>();
    }
    public void BlockBreak()
    {
        animator.SetTrigger("Break");
        blockColider.enabled = false;
        StartCoroutine("Breaking");
    }

    private IEnumerator Breaking()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
}
