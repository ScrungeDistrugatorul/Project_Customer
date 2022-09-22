using System;
using UnityEngine;

public class InteractableZone : MonoBehaviour
{
   public bool interactable;

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         interactable = true;
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         interactable = false;
      }
   }
}
