using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Margot
{
    public class VolumeControll : MonoBehaviour
    {
        public GameObject[] volumeBars;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (ActiveVolumeBars() > 0) 
                {
                    volumeBars[ActiveVolumeBars() - 1].SetActive(false);
                    Debug.Log("lower volume");
                }
            }
            else  if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (ActiveVolumeBars() < volumeBars.Length)
                {
                    volumeBars[ActiveVolumeBars()].SetActive(true);
                    Debug.Log("increase volume");
                }
            }
        }

        int ActiveVolumeBars()
        {
            int activeNum = 0;

            for (int i = 0; i < volumeBars.Length; i++)
            {
                if (volumeBars[i].activeSelf)
                {
                    activeNum++;
                }
            }

            return activeNum;
        }
    }
}

