using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    public bool CanBePressed { get; private set; }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Activator"))
            CanBePressed = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator")
            CanBePressed = false;
    }
}
