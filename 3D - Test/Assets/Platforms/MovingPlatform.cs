using System.Collections;
using UnityEngine;
using DG.Tweening;


public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform platform = null;
    [SerializeField]
    private Transform endPoint = null;
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
        {
            MoveToEnd();
        }
        else
        {
            MoveToStart();
        }
    }
    private void OnDisable()
    {

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
        movingCoroutine = StartCoroutine();
    }
    private void MoveToStart()
    {

    }
    IEnumerator MovePlatform()
    {
        while (true)
        {
            Vector3 targetPos = moveToEnd ? endPoint.transform.position : transform.position;

            //pause for a single frame, next line is the next frame
            yield return null;

            // tinme = distance / speed
            float duration = (platform.transform.position - targetPos).magnitude / moveSpeed;
            Tween moveTween = platform.DOMove(targetPos, duration);

            //come back when anim completes
            yield return moveTween.WaitForCompletion();

            moveTween.Kill();

            //pause for the wait duration
            yield return new WaitForSeconds(waitDuration);
            moveToEnd = !moveToEnd;
        }
    }
}
