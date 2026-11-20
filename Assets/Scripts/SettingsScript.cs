using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class SettingsScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject tab;
    [SerializeField] InputActionReference toggleAction;
    private void Start()
    {
        
    }

    private void OnEnable()
    {
        toggleAction.action.performed += Tab;
        toggleAction.action.Enable();
    }

    private void OnDisable()
    {
        toggleAction.action.performed -= Tab;
        toggleAction.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
       
    }



   public void Tab(InputAction.CallbackContext context)
    {
        // settings.SetActive(!settings.activeSelf);
        switch (tab.activeSelf)
        {
            case true:
                tab.SetActive(false);
                break;
            case false:
                tab.SetActive(true);
                break;
        }
    }
}
