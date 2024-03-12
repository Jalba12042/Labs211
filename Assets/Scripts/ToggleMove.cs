using UnityEngine;
using UnityEngine.UI;

public class ToggleMove : MonoBehaviour
{
    public Toggle toggle;
    public GameObject movingObject;
    public float moveSpeed = 5f;

    private bool isMoving = false;

    private void Update()
    {
        if (isMoving)
        {
            MoveObject();
        }
    }

    public void OnToggleValueChanged(bool isOn)
    {
        isMoving = isOn;
    }

    private void MoveObject()
    {
        movingObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
