
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static UnityEngine.Rendering.DebugUI;

public class SpawnerScript : MonoBehaviour
{
    private static float _difficulty = 0.5f;
    public static float difficulty
    {
        get => _difficulty;
        set
        {
            _difficulty = value;
            foodTimeout = timeout + period * 1.5f;
        }
    }

    public static float foodSpawnDiff;
    [SerializeField]
    private GameObject pipePrefab;
    [SerializeField]
    private GameObject foodPrefab1;
    [SerializeField]
    private GameObject foodPrefab2;
    private static float period => 6.0f-4.0f*difficulty;
    private float pipeOffsetMax = 2.0f;
    private float foodOffsetMax = 4.5f;
    private static float timeout;
    private static float foodTimeout;
    void Start()
    {
        timeout = 0f;
        
    }

    void Update()
    {
        timeout -= Time.deltaTime;
        foodTimeout -= Time.deltaTime;
        if (timeout < 0)
        {
            timeout = period;
            SpawnPipe();
        }
        if (foodTimeout < 0)
        {
            foodTimeout = period;
            SpawnFood();
        }
        Debug.Log(period);
    }

    private void SpawnPipe()
    {
        GameObject pipe = GameObject.Instantiate(pipePrefab);
        pipe.transform.position = this.transform.position+Random.Range(-pipeOffsetMax, pipeOffsetMax) * Vector3.up;
        CountScript.PipeCount+=2;
    }
    private void SpawnFood()
    {
        float value = Random.Range(0, 10);
        if(foodSpawnDiff*10 <= value)
        {
            int key = Random.Range(1, 3);
            GameObject food;
            switch (key)
            {
                case 1:
                    food = GameObject.Instantiate(foodPrefab1);
                    food.transform.position = this.transform.position + Random.Range(-foodOffsetMax, foodOffsetMax) * Vector3.up;
                    food.transform.Rotate(0, 0, Random.Range(0, 360));
                    break;
                case 2:
                    food = GameObject.Instantiate(foodPrefab2);
                    food.transform.position = this.transform.position + Random.Range(-foodOffsetMax, foodOffsetMax) * Vector3.up;
                    food.transform.Rotate(0, 0, Random.Range(0, 360));
                    break;
            }
            CountScript.FoodCount++;
        }
    }
}
