using UnityEngine;

[RequireComponent(typeof(Light))]
public class CausticsLightAnimatorResources : MonoBehaviour
{
    [Header("Flipbook Settings")]
    public string resourceFolder = "Caustics"; // Folder inside Assets/Resources/
    public float fps = 2f;                     // Frames per second

    private Light lightSource;
    private Texture[] causticFrames;
    private float elapsedTime = 0f;
    private int lastFrameIndex = -1;

    void Start()
    {
        lightSource = GetComponent<Light>();

        // Load all textures from Resources/{resourceFolder}
        causticFrames = Resources.LoadAll<Texture>(resourceFolder);

        if (causticFrames.Length == 0)
        {
            Debug.LogError($"No textures found in Resources/{resourceFolder}!");
            return;
        }

        // Assign first frame
        lightSource.cookie = causticFrames[0];
        lastFrameIndex = 0;
    }

    void Update()
    {
        if (causticFrames.Length == 0) return;

        // Update elapsed time
        elapsedTime += Time.deltaTime;

        // Calculate the current frame
        int currentFrameIndex = (int)(elapsedTime * fps) % causticFrames.Length;

        // Only update if the frame changed
        if (currentFrameIndex != lastFrameIndex)
        {
            lightSource.cookie = causticFrames[currentFrameIndex];
            lastFrameIndex = currentFrameIndex;
        }
    }
}
