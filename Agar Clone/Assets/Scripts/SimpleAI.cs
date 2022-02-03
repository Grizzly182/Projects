using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject targetobj;
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb.MovePosition(new Vector3(rb.transform.position.x, targetobj.transform.position.y, 226));
        //transform.Translate(new Vector3(initPosition.x, targetobj.transform.position.y * Time.deltaTime, 226));
    }
}
