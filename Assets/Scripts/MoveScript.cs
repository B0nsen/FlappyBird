using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField]
    private float HardSpeed = 6f;
    [SerializeField]
    private float EasySpeed = 3f;
    [SerializeField]
    private bool Hard = false;
    void Update()
    {
        float speed;
        if(Hard)
        {
            speed = HardSpeed;
        }
        else
        {
            speed = EasySpeed;
        }
        this.transform.Translate(speed * Time.deltaTime * Vector3.left, Space.World);
    }
}
