using UnityEngine;

public class blinking : MonoBehaviour
{
    private float cooldown = 1;

    private SpriteRenderer[] sprites;

    private void Start()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (var sprite in sprites)
        {
            sprite.color = new Color(1f, 1f, 1f, Random.Range(0f, 15f) / 100f);
        }
    }

    void Update()
    {
        if (Time.time >= cooldown)
        {
            cooldown = Time.time + Random.Range(40f, 120f) / 100f;
            foreach (var sprite in sprites)
            {
                sprite.color = new Color(1f, 1f, 1f, Random.Range(0f, 15f) / 100f);
            }
        }
    }
}
