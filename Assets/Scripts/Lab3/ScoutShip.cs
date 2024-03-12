using UnityEngine;

public class ScoutShip : BaseSpaceship
{
    public float agility = 10f;

    protected override void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * movementSpeed * agility * Time.deltaTime;
        transform.Translate(movement);
    }

}
