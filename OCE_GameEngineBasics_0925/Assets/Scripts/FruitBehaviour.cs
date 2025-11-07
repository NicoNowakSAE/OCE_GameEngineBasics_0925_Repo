using UnityEngine;

public class FruitBehaviour : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    private float downwardForce;

    void Start()
    {
        rb.AddForce(Vector2.down * downwardForce, ForceMode2D.Impulse);
    }

    
    void Update()
    {
        
    }
}
