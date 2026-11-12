using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameObject[] objects;

    private int collisionCounter = 0;

    void SwitchActivity()
    {
        if (collisionCounter == 0)
        {
            foreach (var obj in objects)
            {
                obj.SetActive(!obj.activeSelf);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SwitchActivity();
        collisionCounter++;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionCounter--;
        SwitchActivity();
    }
}
