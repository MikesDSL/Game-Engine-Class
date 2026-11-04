using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Vector3 startPos;

    public GameObject camera;

    public float speed;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 distance = camera.transform.position * speed;

        transform.position = new Vector3(startPos.x + distance.x, startPos.y + distance.y,1);
    }
}
