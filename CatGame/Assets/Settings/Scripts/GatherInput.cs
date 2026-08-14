using UnityEngine;

public class GatherInput : MonoBehaviour
{
    public float valueX;
    public bool jumpInput;

    private void Update()
    {
        valueX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jumpInput = true;
        }
    }
}