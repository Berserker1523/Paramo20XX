using UnityEngine;

public class ZombiesSignal : MonoBehaviour
{
    private float radius = 0.2f;
    [SerializeField] private GameObject signal;
    private GameObject signalCanvas;
    private GameObject instantiatedArrow;
    private bool done = false;
    // Update is called once per frame
    void Start()
    {
        signalCanvas = GameObject.FindGameObjectWithTag(GameTags.SignalCanvas.ToString());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals(GameTags.Advertisement.ToString()))
        {
            Vector3 playerPosition = other.transform.position; 
            Vector3 playerDirection = gameObject.transform.position - playerPosition;
            Vector3 playerRightVector = other.transform.right;
            float angle = Vector3.SignedAngle(playerRightVector, playerDirection,Vector3.up);
            
            //Debug.Log($"Angle {angle}");
            float y = radius * Mathf.Sin(Mathf.Deg2Rad*angle);
            float x = radius * Mathf.Cos(Mathf.Deg2Rad * angle);
            //Debug.Log($" x {x}, y {y}");
            Quaternion rotation = Quaternion.Euler(0, 0, -angle);
            //Debug.Log(signalCanvas.transform);
            if (instantiatedArrow == null)
            {
                instantiatedArrow = Instantiate(signal, signalCanvas.transform);
            }

            instantiatedArrow.transform.localRotation = rotation;
            instantiatedArrow.transform.localPosition = new Vector3(x, -y, 0);
        }
    }

    private void OnDestroy()
    {
        Destroy(instantiatedArrow);
    }
}
