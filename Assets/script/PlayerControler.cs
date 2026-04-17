using UnityEngine;
using UnityEngine.InputSystem;//Using
public class PlayerControler : MonoBehaviour
{
    public InputActionReference moveAction;

    public float moveSpeed = 5f;

    private float limity = 3.3f;
    private float myY;

    private void Start()
    {
        myY = transform.position.y;
    }

    private void OnEnable()
    {
        moveAction.action . Enable();
    }
    private void OnDisable()
    {
        moveAction.action . Disable();
    }

    private void Update()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        myY += moveInput.y * moveSpeed * Time.deltaTime;
        myY = Mathf.Clamp(myY, -limity, limity);

        Vector3 pos = transform.position;
        pos.y = myY;
        transform.position = pos;

    }







}
