using UnityEditor.Analytics;
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
    public static void ClearField()
    {
        foreach(var go in GameObject.FindGameObjectsWithTag("Pipe"))
        {
            DeepDestroy(go);
        }
        foreach (var go in GameObject.FindGameObjectsWithTag("Food"))
        {
            DeepDestroy(go);
        }
        foreach (var go in GameObject.FindGameObjectsWithTag("Food2"))
        {
            DeepDestroy(go);
        }
        CountScript.PipeCount = 0;
        CountScript.FoodCount = 0;
    }

    private static void DeepDestroy(GameObject go)
    {
        Transform current = go.transform;
        while (current != null)
        {
            Transform parent = current.parent;
            Destroy(current.gameObject);
            current = parent;
        }
    }
}
