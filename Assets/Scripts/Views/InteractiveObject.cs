using System;
using UnityEngine;

namespace RollABall
{
    public abstract class InteractiveObject : MonoBehaviour, IDisposable, IExecute
    {
        private bool _isInteractable;

        public bool IsInteractable
        {
            get { return _isInteractable; }
            set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            IsInteractable = false;
        }

        protected virtual void Interaction()
        {

        }

        public virtual void Dispose()
        {

        }
        public virtual void Execute()
        {

        }

        private void OnDestroy()
        {
            Dispose();
        }

    }
}