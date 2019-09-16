using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController characterController;
    private Vector3 Velocity;
    [SerializeField]
    private float JumpPower;
    public Transform verRot;//縦の回転をさせるオブジェクト
    public Transform horRot;//横の回転をさせるオブジェクト
    public float MoveSpeed;

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float X_Rotation = Input.GetAxis("Mouse X");//マウスのX軸の移動量だけ横回転させる変数
        float Y_Rotation = Input.GetAxis("Mouse Y");//マウスのY軸の移動量だけ縦回転させる変数
        horRot.transform.Rotate(0, X_Rotation * 2, 0);//横の回転をさせるオブジェクトはY軸をX_Rotation分回転させる
        verRot.transform.Rotate(-Y_Rotation * 2, 0, 0);//縦の回転をさせるオブジェクトはX軸をY_Rotation分回転させる

        if (Input.GetKey(KeyCode.W))
        {
            characterController.Move(this.gameObject.transform.forward * MoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            characterController.Move(this.gameObject.transform.forward * -1f * MoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            characterController.Move(this.gameObject.transform.right * -1 * MoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            characterController.Move(this.gameObject.transform.right * MoveSpeed * Time.deltaTime);
        }

        characterController.Move(Velocity * Time.deltaTime);

        Velocity.y += Physics.gravity.y * Time.deltaTime;
        if (characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Velocity.y = JumpPower;
            }
        }
    }
}