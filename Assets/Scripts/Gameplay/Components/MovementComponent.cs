using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _moveSpeed = 5;

    public void Move(Vector2 direction)
    {
        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;

        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        this.transform.position += moveDirection * scaledMoveSpeed;
    }
 
}
