using UnityEngine;
using UnityEngine.InputSystem;

public class WheelSpinner : MonoBehaviour
{
    [Header("旋轉設定")]
    public float rotateSpeed = 360f;
    public bool clockwise = true;
    public bool startSpinningOnAwake = false;

    [Header("音效設定")]
    [Tooltip("將掛有 AudioSource 的組件或音效拖進來（若不拖，會自動讀取自身身上的 AudioSource）")]
    public AudioSource spinAudioSource;

    private bool isSpinning = false;

    void Start()
    {
        // 如果沒有手動拖入，自動尋找同物件身上的 AudioSource
        if (spinAudioSource == null)
        {
            spinAudioSource = GetComponent<AudioSource>();
        }

        isSpinning = startSpinningOnAwake;

        // 如果一開始就要轉，且有音效，就播放
        if (isSpinning && spinAudioSource != null)
        {
            spinAudioSource.Play();
        }
    }

    void Update()
    {
        // 滑鼠左鍵點擊
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            isSpinning = !isSpinning;

            // 控制音效播放 / 暫停
            if (spinAudioSource != null)
            {
                if (isSpinning)
                {
                    spinAudioSource.Play();   // 開始轉動時播放
                }
                else
                {
                    spinAudioSource.Pause();  // 暫停時停止音效
                }
            }
        }

        // 旋轉邏輯
        if (isSpinning)
        {
            float direction = clockwise ? -1f : 1f;
            transform.Rotate(0, 0, direction * rotateSpeed * Time.deltaTime);
        }
    }
}
