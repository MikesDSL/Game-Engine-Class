using UnityEngine;

public class PermanentButtonHandler : MonoBehaviour
{
    public GameObject[] objects;

    bool still = true;

    void SwitchActivity()
    {
            foreach (var obj in objects)
            {
                obj.SetActive(!obj.activeSelf);
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!still) { return; }
        SwitchActivity();
        still = false;
    }
}
