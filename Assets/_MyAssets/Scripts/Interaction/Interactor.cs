using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using System;

public class Interactor : MonoBehaviour
{
    private IInteractable _objectToInteract;
    private IInteractable _lastObjectToInteract;
    
    private float _interactablesFound;
    private bool _canInteract;
    [SerializeField] Camera _cam;
    [SerializeField] private float interactRange;
    [SerializeField] private float interactRadius;
    [SerializeField] private Transform interactPoint;
    [SerializeField] private LayerMask interactableMask;
    Collider[] colliders = new Collider[1];
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canInteract)
        {
            Debug.Log("interact?");
            _objectToInteract.Interact();
        }
        
    }

    private void FixedUpdate()
    {

        if(Physics.Raycast(_cam.transform.position, _cam.transform.forward, out RaycastHit hit, interactRange, interactableMask,
            QueryTriggerInteraction.Collide))
        {
            _objectToInteract = hit.collider.gameObject.GetComponent<IInteractable>();
            
            if(_objectToInteract != _lastObjectToInteract) _lastObjectToInteract?.StopHighlight();

            if (_objectToInteract != null)
            {
                if (!_objectToInteract.Interacted())
                {
                    _lastObjectToInteract = _objectToInteract;
                    _objectToInteract.Highlight();
                    _canInteract = true;
                }
                else
                {
                    _canInteract = false;
                    _objectToInteract.StopHighlight();
                }
            }
            else _canInteract = false;

        }
        else
        {
            _lastObjectToInteract?.StopHighlight();
            _lastObjectToInteract = null;
            _canInteract = false;
        }
        
        
        /*
         _interactablesFound = Physics.OverlapCapsuleNonAlloc(_cam.transform.position, interactPoint.position, interactRadius, colliders, interactableMask);
        if(_interactablesFound > 0)
        {
            Debug.Log("colision");
            _objectToInteract = colliders[0].gameObject.GetComponent<IInteractable>();

            if (_objectToInteract != null && Input.GetKeyDown(KeyCode.E))
            {
                _objectToInteract.Interact();
            }
        }
        else
        {
            _objectToInteract = null;
            //Array.Clear(colliders, 0, colliders.Length);
        }
        */
    }

    public IInteractable GetInteractable()
    {
        return _objectToInteract;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(_cam.transform.position, interactPoint.position);
    }
}
