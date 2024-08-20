using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Margot
{
    public class Ending : MonoBehaviour
    {
        Animator anim;

        public StageTwoManager manager;

        public SpriteRenderer BGClassRoom1;
        public SpriteRenderer BGClassRoom2;

        public Light2D DarkLight;

        public GameObject friendsSilhouette;
        public GameObject playerLight;
        
        

        void Awake()
        {
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            if (manager.stageClear)
            {
                anim.SetTrigger("Start");
            }
        }

        public void SetEnvironment()
        {

            // �� ���� ��� ��ȭ

            Color newColor = BGClassRoom1.color;
            newColor.r = 1;
            newColor.g = 1;
            newColor.b = 1;

            BGClassRoom1.color = newColor;
            BGClassRoom2.color = newColor;


            // ��ο� �� �����ֱ�
            DarkLight.color = newColor;

            // ģ���� �Ƿ翧 �����ֱ�
            friendsSilhouette.SetActive(true);

            // �÷��̾� �ֺ� �� ��Ȱ��ȭ �� ���� Ȱ��ȭ
            playerLight.SetActive(false);

            // �ð�ȭ�� ������ ��ȣ�ۿ� ��Ȱ��ȭ
            manager.hideInteractions = true;

        }


        public void ToNextStage()
        {
            // ���� ������
        }
    }

}
