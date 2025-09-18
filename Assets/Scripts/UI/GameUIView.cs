using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIView : MonoBehaviour
{
    [Header("Player Sanity")]
    [SerializeField] GameObject rootViewPanel;
    [SerializeField] Image insanityImage;
    [SerializeField] Image redVignette;

    [Header("Keys UI")]
    [SerializeField] TextMeshProUGUI keysFoundText;

    [Header("Game End Panel")]
    [SerializeField] GameObject gameEndPanel;
    [SerializeField] TextMeshProUGUI gameEndText;
    [SerializeField] Button tryAgainButton;
    [SerializeField] Button quitButton;

    private void OnEnable()
    {
        tryAgainButton.onClick.AddListener(OnTryAgainButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
        EventService.Instance.OnKeyPickup.Subscribe(updateKeyText);
    }
    public void UpdateInsanity(float playerSanity) => insanityImage.rectTransform.localScale = new Vector3(1, playerSanity, 1);
    private  void updateKeyText(int keys) => keysFoundText.SetText($"Keys Found: {keys}/3");

    private void OnQuitButtonClicked() => Application.Quit();
    private void OnTryAgainButtonClicked() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void OnDisable()=> EventService.Instance.OnKeyPickup.Unsubscribe(updateKeyText);

}

