using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Splines; // required for SplineAnimate

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable))]
public class VRButtonTrigger : MonoBehaviour
{
    [Header("Assign the camera object with SplineAnimate")]
    public SplineAnimate cameraSplineAnimate;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnPressed);
        }
    }

    private void OnDestroy()
    {
        if (interactable != null)
            interactable.selectEntered.RemoveListener(OnPressed);
    }

    private void OnPressed(SelectEnterEventArgs args)
    {
        if (cameraSplineAnimate != null)
        {
            cameraSplineAnimate.Play();
        }
    }
}
