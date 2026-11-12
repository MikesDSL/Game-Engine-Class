using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject != null)
        {
            PlayerController pc = other.gameObject.GetComponent<PlayerController>();
            if (pc != null)
            {
                other.transform.parent = transform;
            }
        }    
    }
    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.gameObject != null)
        {
            PlayerController pc = other.gameObject.GetComponent<PlayerController>();
            if (pc != null)
            {
                other.transform.parent = null;
            }
        }
    }
}
