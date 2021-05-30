using UnityEngine;

public class BulletRotate : MonoBehaviour
{
    [SerializeField] private GameObject _Particle;
    new Transform transform;
    const float MoveSpeed = 10f;

    void Awake()
    {
        transform = GetComponent<Transform>();

        FindObjectOfType<PauseHandler>().PauseAction += OnPauseStateChanged;
    }

    void Update()
    {
        Vector3 direction = transform.up;
        float speed = MoveSpeed * Time.deltaTime;
        transform.Translate(direction * speed, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Sprite spr = other.transform.gameObject.GetComponent<SpriteRenderer>().sprite;
        other.transform.parent.position -= new Vector3((spr.rect.width / spr.pixelsPerUnit) / 2, 0, 0);

        Instantiate(_Particle, other.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnPauseStateChanged(bool state)
    {
        enabled = !state;
    }
}