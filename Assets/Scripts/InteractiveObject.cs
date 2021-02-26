using System;
using UnityEngine;

namespace RollABall
{
    public abstract class InteractiveObject : MonoBehaviour, IDisposable
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

        public virtual void Dispose()
        {

        }

        private void OnDestroy()
        {
            Dispose();
        }
    }
}