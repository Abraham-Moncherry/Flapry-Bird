using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class scrollingBackgroundScript : MonoBehaviour
{
    public float speed = 0.2f;

    [SerializeField] private Renderer bgRenderer;

    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
