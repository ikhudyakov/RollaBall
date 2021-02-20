using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public abstract class InteractiveObject : MonoBehaviour
    {
        public bool IsInteractable { get; } = true;

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            Destroy(gameObject);
        }

        protected virtual void Interaction()
        {

        }
    }
}