using UnityEngine;
using UnityEngine.InputSystem; // 引入新版輸入系統

public class WheelSpinner : MonoBehaviour
{
    [Header("旋轉設定")]
    public float rotateSpeed = 360f;
    public bool clockwise = true;
    public bool startSpinningOnAwake = false;

    private bool isSpinning = false;

    void Start()
    {
        isSpinning = startSpinningOnAwake;
    }

    void Update()
    {
        // 新版輸入系統的點擊偵測
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            isSpinning = !isSpinning;
        }

        // 旋轉邏輯
        if (isSpinning)
        {
            float direction = clockwise ? -1f : 1f;
            transform.Rotate(0, 0, direction * rotateSpeed * Time.deltaTime);
        }
    }
}
