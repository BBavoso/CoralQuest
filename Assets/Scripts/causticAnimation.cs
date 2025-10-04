using UnityEngine;

public class CausticAnimator : MonoBehaviour
{
    public Light targetLight;
    public string causticFolder = "Assets/Resources/Caustics/caustic_"; // path inside Resources
    public int totalFrames = 50;
    public float frameRate = 20f; // frames per second

    private Texture[] caustics;
    private int currentFrame = 0;
    private float timer = 0f;

    void Start()
    {
        // Load all textures dynamically
        caustics = new Texture[totalFrames];
        for (int i = 1; i <= totalFrames; i++)
        {
            caustics[i - 1] = Resources.Load<Texture>(causticFolder + i);
        }
    }

    void Update()
    {
        if (caustics.Length == 0) return;

        timer += Time.deltaTime;
        if (timer >= 1f / frameRate)
        {
            timer = 0f;
            currentFrame = (currentFrame + 1) % totalFrames;
            targetLight.cookie = caustics[currentFrame];
        }
    }
}