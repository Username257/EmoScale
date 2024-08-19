using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace User257
{
    [RequireComponent(typeof(WheelResizer))]
    public class Burden : MonoBehaviour
    {
        public UnityAction OnDisappear;
        float originalScale;
        float curScale;

        [SerializeField] float sizingSpeed;

        private void Awake()
        {
            originalScale = transform.localScale.x;    
        }

        private void Update()
        {
            MaintainSize();
            CompareScale();
        }

        void CompareScale()
        {
            if (transform.localScale.x < 0.1f)
            {
                OnDisappear?.Invoke();
                gameObject.SetActive(false);
            }
        }

        void MaintainSize()
        {
            curScale = transform.localScale.x;
            float time = Time.deltaTime * sizingSpeed * curScale; //curScale�� ���� �۾��� ��ü�� �ʹ� ������ Ŀ���� �ʰ� ����
            
            transform.localScale = new Vector3(Mathf.Lerp(curScale, originalScale, time), Mathf.Lerp(curScale, originalScale, time), Mathf.Lerp(curScale, originalScale, time));
        }
    }
}
