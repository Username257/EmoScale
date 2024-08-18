using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Margot
{
    public class StageTwoManager : MonoBehaviour
    {
        public bool pickedUpPhone = false;
        public bool showBox = false;
        public bool interacted = false;

        public Transform[] boxPos;
        public GameObject phoneObj;
        public GameObject boxObj;

        [HideInInspector]
        public string interactKey;

        Coroutine phone;

        public GameObject InteractUICanavs;

        void Start()
        {
            boxObj.SetActive(false);
            InteractUICanavs.SetActive(false);
        }

        void Update()
        {
            if (!pickedUpPhone)
            {
                if (!showBox)
                {
                    phone = StartCoroutine(ReadyToStart());
                }
                else
                {
                    boxObj.transform.position = boxPos[0].position;
                    boxObj.SetActive(true);
                    interactKey = "E";

                    if (interacted)
                    {
                        boxObj.GetComponent<InteractionBox>().Disappearing();
                        Destroy(phoneObj);
                        StopCoroutine(phone);
                        InteractUICanavs.SetActive(true);
                        pickedUpPhone = true;
                    }
                }
            }       
        }

        IEnumerator ReadyToStart()
        {
            yield return new WaitForSeconds(2f);

            showBox = true;
        }

    }
}

