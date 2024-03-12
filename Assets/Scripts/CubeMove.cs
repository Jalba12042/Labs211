using UnityEngine;
using UnityEngine.UI;

public class CubeMove : MonoBehaviour
{
    public Toggle toggle;
    public float moveSpeed = 1f;
    public Vector2 boundarySize;

    private bool isMoving = false;

    void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    void Update()
    {
        if (isMoving)
        {
            MoveRandomly();
        }
    }

    void OnToggleValueChanged(bool newValue)
    {
        isMoving = newValue;
    }

    void MoveRandomly()
    {
        float randomX = Random.Range(-boundarySize.x / 2f, boundarySize.x / 2f);
        float randomY = Random.Range(-boundarySize.y / 2f, boundarySize.y / 2f);
        Vector3 randomDirection = new Vector3(randomX, randomY, 0f).normalized;
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime);
    }
}
