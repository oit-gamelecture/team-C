using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemys : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    public float detectionRange = 5f;  // �v���C���[�����o����͈�
    public Vector3 initialDirection = Vector3.forward;  // Z�������i�O�����j�Ɉړ�
    public Transform player;  // �v���C���[��Transform

    private Vector3 currentDirection;
    void Start()
    {
        // �����ړ�������ݒ�
        currentDirection = initialDirection;
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�Ƃ̋������v�Z
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // �v���C���[���͈͓��ɂ���ꍇ�AX�������Ɉړ�
            if (player.position.x > transform.position.x)
            {
                // �v���C���[���E�ɂ���ꍇ�A�E�i+X�����j�Ɉړ�
                currentDirection = Vector3.right;
            }
            else
            {
                // �v���C���[�����ɂ���ꍇ�A���i-X�����j�Ɉړ�
                currentDirection = Vector3.left;
            }
        }
        else
        {
            // �v���C���[���͈͊O�ɂ���ꍇ�AZ�������ɖ߂�
            currentDirection = initialDirection;
        }

        // �G���ړ�������
        transform.Translate(currentDirection * speed * Time.deltaTime, Space.World);
    }
}
