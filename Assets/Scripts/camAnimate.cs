using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Splines;

public class CamAnimate : MonoBehaviour
{
    [SerializeField] private SplineAnimate spline;
    [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable; // works with XR Simple Interactable
    private Renderer cubeRenderer;
    private Color originalColor;
    [SerializeField] private Color pressedColor = Color.green;

    void Start()
    {
        // Cache renderer for visual feedback
        cubeRenderer = GetComponent<Renderer>();
        if (cubeRenderer != null)
            originalColor = cubeRenderer.material.color;

        // Find the XR Simple Interactable if not assigned
        if (interactable == null)
            interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();

        if (interactable == null)
        {
            Debug.LogError("No XR Simple Interactable or XR Base Interactable found on this object!");
            return;
        }

        // Subscribe to the “pressed” event
        interactable.selectEntered.AddListener(OnPressed);
        interactable.selectExited.AddListener(OnReleased);
    }

    private void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnPressed);
            interactable.selectExited.RemoveListener(OnReleased);
        }
    }

    private void OnPressed(SelectEnterEventArgs args)
    {
        Debug.Log("Button pressed!");

        // Change color to show it’s being pressed
        if (cubeRenderer != null)
            cubeRenderer.material.color = pressedColor;

        // Trigger spline
        if (spline != null)
        {
            spline.Play();
            Debug.Log("Spline started!");
        }
        else
        {
            Debug.LogWarning("Spline reference missing!");
        }
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        Debug.Log("Button released!");
        if (cubeRenderer != null)
            cubeRenderer.material.color = originalColor;
    }
}
