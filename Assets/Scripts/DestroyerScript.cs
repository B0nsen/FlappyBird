using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform current = collision.transform.parent;
        if(collision.CompareTag("Pipe"))
        {
            CountScript.PipeCount--;
        }
        else if(collision.CompareTag("Food") || collision.CompareTag("Food2"))
        {
            CountScript.FoodCount--;
        }
        while (current != null)
        {
            Transform parent = current.parent;
            Destroy(current.gameObject);
            current = parent;
        }
    }
}
