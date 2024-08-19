using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace User257
{
    public class MouseProtractor : MonoBehaviour
    {
        [SerializeField] Transform mouseFollower; 

        public Vector2 GetAngle()
        {
            Vector2 dirToMouse = transform.position - mouseFollower.transform.position;

            return dirToMouse.normalized * -1f; //-1f �� ���� ������ �ƴ϶� ����� �������� �ϱ� ����
        }
    }
}
