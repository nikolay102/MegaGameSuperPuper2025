using UnityEngine;

public class CubeMoving : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float radius = 1f;
    [SerializeField] private float direction = 1f;
    [SerializeField] private GameObject cube;
    private float angle = 0f;
    [SerializeField] private Vector3 startPos = Vector3.zero;
    [SerializeField] private Vector3 rotationAxis = Vector3.up;

    void Awake()
    {
        if (cube == null)
        {
            cube = cube.GetComponent<GameObject>();
        }
    }
    
     void Update()
     {
         MoveCube();
         if (rotationAxis != Vector3.zero)
         {
             transform.LookAt(startPos, rotationAxis);
         }
     }

    void MoveCube()
    {
        angle += (moveSpeed*direction) * Time.deltaTime;
        
        float x = startPos.x + radius * Mathf.Cos(angle);
        float z = startPos.z + radius * Mathf.Sin(angle);
        
        cube.transform.position = new Vector3(x, startPos.y, z);
    }
}
