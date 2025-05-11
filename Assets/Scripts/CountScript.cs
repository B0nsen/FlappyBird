using UnityEngine;

public class CountScript : MonoBehaviour
{
    public static int FoodCount;
    public static int PipeCount;
    private TMPro.TextMeshProUGUI food;
    private TMPro.TextMeshProUGUI pipe;
    void Start()
    {
        FoodCount = 0;
        PipeCount = 0;
        food = transform.Find("FoodCount").GetComponent<TMPro.TextMeshProUGUI>();
        pipe = transform.Find("PipeCount").GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        food.text = $"Food: {FoodCount}";
        pipe.text = $"Pipe: {PipeCount}";
    }
}
