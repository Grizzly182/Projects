using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(SpriteRenderer), typeof(Transform))]
public class Player : MonoBehaviour, IBall, IMovable, IConsumable
{
    [SerializeField] private GameObject arrow;

    private SpriteRenderer _spriterenderer;

    public Vector3 StartSize
    {
        get { return new Vector3(50, 50, 50); }
        set { }
    }

    public float Saturation
    {
        get { return 1; }
        set { }
    }

    private void Awake()
    {
        _spriterenderer = GetComponent<SpriteRenderer>();
        _spriterenderer.GenerateRandomColor();
    }

    private void Start()
    {
        CameraCorrect();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            arrow.SetActive(true);
            Move();
        }
        else
        {
            arrow.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Food food = col.gameObject.GetComponent<Food>();
        Consume(food);
    }

    public void Move()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Ended)
        {
            arrow.SetActive(false);
        }
        else
        {
            arrow.SetActive(true);
        }
        Vector3 target = Camera.main.ScreenToWorldPoint(touch.position);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.x, target.y, 1),
            Time.deltaTime * 100f);

        ClampPlayerPos();

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y, Mathf.Atan2(target.y - transform.position.y,
            target.x - transform.position.x) * Mathf.Rad2Deg - 90);
    }

    public void Consume(Food food)
    {
        switch (food.Type)
        {
            case FoodType.Food:
                Eat(food);
                break;
            case FoodType.Bot:
                if(food.transform.localScale.x >= transform.localScale.x)
                {
                    return;
                }
                else
                {
                    Eat(food);
                }
                break;
        }
        
    }

    private void CameraCorrect()
    {
        Camera cam = Camera.main;
        cam.orthographicSize = 250 + transform.localScale.x;
    }

    private void ClampPlayerPos()
    {
        float x = Mathf.Clamp(transform.position.x, 0f, Map.XLimit);
        float y = Mathf.Clamp(transform.position.y, 0f, Map.YLimit);
        transform.position = new Vector3(x, y, transform.position.z);
    }

    private void Eat(Food food)
    {
        transform.localScale = new Vector3(transform.localScale.x + food.Saturation, transform.localScale.y + food.Saturation, transform.localScale.z);
        CameraCorrect();
        Destroy(food.gameObject);
    }
}