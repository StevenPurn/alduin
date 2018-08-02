using UnityEngine;

public class RotateAfterTime : MonoBehaviour {

    [SerializeField]
    private Vector3 targetRotation;
    [SerializeField]
    private float rotationTimer = 10f;
    private float rotationTime;
    private bool rotating;

    void Start()
    {
        rotationTime = rotationTimer;
    }

    void Update()
    {

        rotationTime -= Time.deltaTime;

        if (rotationTime <= 0)
        {
            rotating = true;
        }
        if (rotating)
        {
            Rotate();
        }
    }

    void Rotate()
    {
        transform.Rotate(targetRotation);
        rotationTime = rotationTimer;
        rotating = false;
    }
}
