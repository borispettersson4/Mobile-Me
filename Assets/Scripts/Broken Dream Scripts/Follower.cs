using System;
using UnityEngine;

    public class Follower : MonoBehaviour
    {
        public bool copyRotation = false;
        public Transform target;
        public Vector3 offset = new Vector3(0f, 7.5f, 0f);
        public float smoothScale = 0;
        public float smoothRotScale = 0;
        public Transform lookTarget;

    void Awake()
    {
        transform.LookAt(lookTarget);
    }


        private void LateUpdate()
        {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothScale * Time.deltaTime);
        transform.LookAt(lookTarget);
   //     transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
    }
    }
