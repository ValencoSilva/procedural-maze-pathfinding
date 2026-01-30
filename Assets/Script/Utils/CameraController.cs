using UnityEngine;

///Camera control to adjust the view of the generated maze depending on its size
public class CameraController : MonoBehaviour
{
    public Transform mazeTransform;

    //Extra spacing around the maze
    public float padding = 2f;

    //Fixed camera height in relation to the maze
    public float heightOffset = 10f; 

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    //Adjusts camera position and zoom based on maze size
    public void AdjustCamera(int mazeWidth, int mazeHeight)
    {
       
        Vector3 center = new Vector3(mazeWidth / 2f, mazeHeight / 2f, transform.position.z);
        transform.position = center;

       
        float maxDimension = Mathf.Max(mazeWidth, mazeHeight);
        cam.orthographicSize = maxDimension / 2f + padding;
    }
}
