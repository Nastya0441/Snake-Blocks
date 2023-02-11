using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraQ : MonoBehaviour
    {
        private Transform target;
        public Vector3 cam = new(-0.38f, 2.51f, -3.7f);

        void Start()
        {
            target = GameObject.Find("Player").transform;
        }

         void LateUpdate()
        {
            this.transform.position = target.TransformPoint(cam);
            this.transform.LookAt(target);

            if (transform.position != null)
            {
                return;
            }
        }

    }
}
