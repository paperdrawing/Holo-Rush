using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace HoloRush
{
    public class RainbowImage : MonoBehaviour
    {
        [SerializeField]
        private Image m_image;
        [SerializeField]
        private SpriteRenderer m_spriteRenderer;
        [SerializeField]
        private float m_duration = 1;
        [SerializeField]
        private float m_saturation = 1;
        [SerializeField]
        private float m_value = 1;

        private Tween tween;
        private float m_hue;

        private void Start()
        {
            tween = DOTween.To(() => m_hue, f =>
            {
                Color color = Color.HSVToRGB(f, m_saturation, m_value);
                if (m_image)
                {
                    color.a = m_image.color.a;
                    m_hue = f; m_image.color = color;
                }
                if (m_spriteRenderer)
                {
                    color.a = m_spriteRenderer.color.a;
                    m_hue = f; m_spriteRenderer.color = color;
                }
            }, 1, m_duration).OnComplete(() => m_hue = 0).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        }

        private void OnEnable()
        {
            tween.Play();
        }

        private void OnDisable()
        {
            tween.Pause();
        }
    }
}
