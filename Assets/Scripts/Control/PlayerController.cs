using System.Collections;
using UnityEngine;
using RPG.Movement;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        Mover mover;

        // UNITY METHODS

        private void Awake()
        {
            mover = GetComponent<Mover>();
        }
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        // PRIVATE METHODS
        private void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);
            if (hasHit)
            {
                mover.MoveTo(hit.point);
            }
        }
    }
}