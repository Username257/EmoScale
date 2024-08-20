using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

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

        public GameObject kidsSoundObj;

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
            SfxManager.instance.ShockwavePosSoundPlay();

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

        public void SoundPlay()
        {
            kidsSoundObj.SetActive(true);
        }

        public void ShockWaveSoundPlay()
        {
            SfxManager.instance.ShockwavePosSoundPlay();
        }


        public void ToNextStage()
        {
            // ���� ������
            GameManager.Instance.SetStageClear(GameManager.Stage.Student);
            SceneManager.LoadScene("Stage_3_1");
        }
    }

}
