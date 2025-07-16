using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [Header("VR Score Display")]
    //World Space Canvas: Creates ammo display that exists in 3D world space, not screen space
    [SerializeField] private Canvas ammoCanvas; // World Space Canvas
    [SerializeField] private TextMeshProUGUI ammoText; // Use TextMeshPro for better VR text
    [SerializeField] private Transform ammoDisplayPosition; // Where to position the ammo display
    [SerializeField] private float ammoDisplayScale = 0.01f; // Scale for VR world space
//[SerializeField] private bool alwaysFacePlayer = true; // Should ammo always face the player
    [SerializeField] private float Ammotextsize = 5f;
    //private bool isFlashing = false; // This flag prevent toggling reload and 0 by frame
    public Zmotion PlayerScoreRef;

    [Header("VR Score Title Display")]
    //World Space Canvas: Creates ammo display that exists in 3D world space, not screen space
    [SerializeField] private Canvas TitleCanvas; // World Space Canvas
    [SerializeField] private TextMeshProUGUI TitleText; // Use TextMeshPro for better VR text
    [SerializeField] private Transform TitleDisplayPosition; // Where to position the ammo display
    [SerializeField] private float TitleDisplayScale = 0.01f; // Scale for VR world space
                                                             //[SerializeField] private bool alwaysFacePlayer = true; // Should ammo always face the player
    [SerializeField] private float Titletextsize = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupAmmoDisplay();
        SetupTitleDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmoDisplay();
    }

    void SetupAmmoDisplay()
    {
        // If no canvas is assigned, create one
        if (ammoCanvas == null)
        {
            GameObject canvasGO = new GameObject("AmmoCanvas");
            ammoCanvas = canvasGO.AddComponent<Canvas>();
            canvasGO.AddComponent<CanvasScaler>();
            canvasGO.AddComponent<GraphicRaycaster>();
        }

        // Configure canvas for world space
        ammoCanvas.renderMode = RenderMode.WorldSpace;
        ammoCanvas.transform.SetParent(transform); // Parent to gun

        // Position the canvas
        if (ammoDisplayPosition != null)
        {
            ammoCanvas.transform.position = ammoDisplayPosition.position;
            ammoCanvas.transform.rotation = ammoDisplayPosition.rotation;
        }
        else
        {
            // Default position: slightly above and in front of gun
            ammoCanvas.transform.localPosition = new Vector3(0, 0.1f, 0.2f);
            ammoCanvas.transform.localRotation = Quaternion.identity;
        }

        // Scale the canvas for VR
        ammoCanvas.transform.localScale = Vector3.one * ammoDisplayScale;

        // Set up the text component
        if (ammoText == null)
        {
            GameObject textGO = new GameObject("AmmoText");
            textGO.transform.SetParent(ammoCanvas.transform);
            ammoText = textGO.AddComponent<TextMeshProUGUI>();
        }

        // Configure the text
        ammoText.text = PlayerScoreRef.score.ToString();//Initialises, we have to update this in update
        ammoText.fontSize = Ammotextsize; // Large font size for world space
        ammoText.color = Color.white;
        ammoText.alignment = TextAlignmentOptions.Center;
        ammoText.fontStyle = FontStyles.Italic;

        // Position text in canvas
        RectTransform textRect = ammoText.GetComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = Vector2.zero;
        textRect.offsetMax = Vector2.zero;

        // Add outline to digit.
        if (ammoText.fontSharedMaterial != null)
        {
            ammoText.outlineWidth = 0.2f;
            ammoText.outlineColor = Color.black;
        }
    }

    //This function call updates the ammo display.
    void UpdateAmmoDisplay()
    {
        if (ammoText != null)//This check is helpful for public var/serialised var.
        {
            ammoText.text = PlayerScoreRef.score.ToString();

            
        }
    }

    void SetupTitleDisplay() 
    {
        if (TitleCanvas == null)
        {
            return;
        }
        TitleCanvas.renderMode = RenderMode.WorldSpace;
        TitleCanvas.transform.SetParent(transform); // Parent to gun

        if (TitleDisplayScale != null)
        {
            TitleCanvas.transform.position = TitleDisplayPosition.position;
            TitleCanvas.transform.rotation = TitleDisplayPosition.rotation;
        }
        if (TitleText == null) { return; }

        TitleText.text = "Score:-";//Initialises, we have to update this in update
        TitleText.fontSize = Ammotextsize; // Large font size for world space
        TitleText.color = Color.white;
        TitleText.alignment = TextAlignmentOptions.Center;
        TitleText.fontStyle = FontStyles.Italic;

        // Position text in canvas
        RectTransform textRect = TitleText.GetComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = Vector2.zero;
        textRect.offsetMax = Vector2.zero;

        // Add outline to digit.
        if (ammoText.fontSharedMaterial != null)
        {
            ammoText.outlineWidth = 0.2f;
            ammoText.outlineColor = Color.black;
        }
    }

}
