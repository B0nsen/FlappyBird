using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;
    [SerializeField]
    private GameObject foodPrefab;
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
    }
    private void SpawnFood()
    {
        GameObject food = GameObject.Instantiate(foodPrefab);
        food.transform.position = this.transform.position+Random.Range(-foodOffsetMax, foodOffsetMax) * Vector3.up;
        food.transform.Rotate(0, 0, Random.Range(0, 360));
    }
}
