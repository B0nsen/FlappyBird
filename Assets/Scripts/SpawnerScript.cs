
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;
    [SerializeField]
    private GameObject foodPrefab1;
    [SerializeField]
    private GameObject foodPrefab2;
    private float period = 3.0f;
    private float pipeOffsetMax = 2.0f;
    private float foodOffsetMax = 4.5f;
    private float timeout;
    private float foodTimeout;
    void Start()
    {
        timeout = 0f;
        foodTimeout = 1.5f;
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
    }

    private void SpawnPipe()
    {
        GameObject pipe = GameObject.Instantiate(pipePrefab);
        pipe.transform.position = this.transform.position+Random.Range(-pipeOffsetMax, pipeOffsetMax) * Vector3.up;
        CountScript.PipeCount+=2;
    }
    private void SpawnFood()
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
