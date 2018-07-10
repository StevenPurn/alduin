using UnityEngine;

public class FaceTowards : MonoBehaviour {

    public Transform target;
    public bool faceTowards;

	void Update () {
        if (faceTowards)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(transform.position - target.position);
        }
	}
}
