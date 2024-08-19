using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    private float step_time; // �o�ߎ��ԃJ�E���g�p
    public Text CountText;
    int count;

    // Use this for initialization
    void Start()
    {
        step_time = 4.0f;       // �o�ߎ��ԏ�����
    }

    // Update is called once per frame
    void Update()
    {
        // �o�ߎ��Ԃ��J�E���g
        step_time -= Time.deltaTime;

        count = (int)step_time;

        if (count > 0)
        {

            CountText.text = count.ToString();

        }
        else
        {
            CountText.text = ("start");
        }
        
        // 3�b��ɉ�ʑJ�ځiscene2�ֈړ��j
        if (step_time <= 0.0f)
        {
            SceneManager.LoadScene("main");
        }
    }
}
