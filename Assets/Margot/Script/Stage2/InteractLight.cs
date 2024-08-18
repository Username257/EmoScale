using Margot;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Marogt
{
    public class InteractLight : MonoBehaviour
    {
        public GameObject player;
        public StageTwoManager manager;

        public bool isDetectable = false;

        Light2D soundLight;
        Coroutine adjustLight;

        public int order = 0;

        [SerializeField]
        float distance = 0f;

        void Awake()
        {
            soundLight = GetComponent<Light2D>();
        }

        void Update()
        {
            distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
            bool currentlyDetectable = distance <= manager.distanceToDetect;

            if (currentlyDetectable != isDetectable)
            {
                isDetectable = currentlyDetectable;

                if (adjustLight != null)
                {
                    StopCoroutine(adjustLight); // �̹� ���� ���� �ڷ�ƾ�� ������ ����
                }

                if (isDetectable)
                {
                    adjustLight = StartCoroutine(AdjustLight(1f)); // ��ǥ ���� 1f�� �����Ͽ� ���� ũ�⸦ ����                    
                }
                else
                {                   
                    adjustLight = StartCoroutine(AdjustLight(0f)); // ��ǥ ���� 0f�� �����Ͽ� ���� ũ�⸦ ����
                }
            }


            /* ���� �ڷ�ƾ�� ����ؼ� ���������� ������� ��ο����⿡ �� ���� ���������� �ߴµ�(���� if��)
               ��ȣ�ۿ� �ڽ��� ��� ������� ������ ������ �ϱ� ������ �ؿ�ó�� ����
             */

            if (isDetectable && manager.pickedUpPhone)
            {
                if (distance <= 3)
                {
                    Debug.Log(order + "time to show box");
                    manager.ShowInteractBox(order, "E");
                }
                else
                {
                    Debug.Log("hide");
                    manager.HideInteractBox();
                }
            }
            else if (!isDetectable && manager.pickedUpPhone) 
            {
                Debug.Log("hide");
                manager.HideInteractBox();
            }
        }

        IEnumerator AdjustLight(float target)
        {
            float initialLightSize = soundLight.pointLightOuterRadius;
            float currentTime = 0.0f;
            float time = 1f;

            while (currentTime <= time)
            {
                // �������� ���������� ����
                soundLight.pointLightOuterRadius = Mathf.Lerp(initialLightSize, target, currentTime / time);
                currentTime += Time.deltaTime; // ��� �ð� ����
                yield return null; // ���� �����ӱ��� ���
            }

            soundLight.pointLightOuterRadius = target; // ���������� ��ǥ �����Ͽ� ����
        }
    }
}
