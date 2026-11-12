using DG.Tweening;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform platform = null;
    [SerializeField]
    private Transform startPos = null;
    [SerializeField]
    private Transform endPos = null;
    [SerializeField]
    private float moveSpeed = 2.0f;
    [SerializeField]
    private float waitDuration = 2.0f;

    private Coroutine movingCoroutine = null;
    private bool moveToEnd = true;

    private void OnEnable()
    {
        ClearCoroutine();
        if (moveToEnd)
            MoveToEnd();
        else
            MoveToStart();
    }
    private void OnDisable()
    {
        ClearCoroutine();
    }
    private void ClearCoroutine()
    {
        if (movingCoroutine != null)
        {
            StopCoroutine(movingCoroutine);
        }
        movingCoroutine = null;
    }
    private void MoveToEnd()
    {
        moveToEnd = true;
        movingCoroutine = StartCoroutine(MovePlatform());
    }
    private void MoveToStart()
    {
        moveToEnd = false;
        movingCoroutine = StartCoroutine(MovePlatform());
    }
    IEnumerator MovePlatform()
    {
        while (true)
        {
            Vector3 targetPos = moveToEnd ? endPos.transform.position: startPos.transform.position;

            yield return null;

            float duration = (platform.transform.position - targetPos).magnitude / moveSpeed;
            Tween moveTween = platform.DOMove(targetPos, duration);

            yield return moveTween.WaitForCompletion();

            moveTween.Kill();

            yield return new WaitForSeconds(waitDuration);

            moveToEnd = !moveToEnd;
        }
    }
}
