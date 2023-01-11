using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    [Header("Login")]
    [SerializeField] private InputField m_loginPasswordInput = null;
    [SerializeField] private InputField m_loginUserNameInput = null;


    [Header("Register")]
    [SerializeField] private InputField m_userNameInput = null;
    [SerializeField] private InputField m_emailInput = null;
    [SerializeField] private InputField m_password = null;
    [SerializeField] private InputField m_reEnterPassword = null;
    [SerializeField] private Text m_text = null;
    [SerializeField] private GameObject m_registerUI = null;
    [SerializeField] private GameObject m_loginUI = null;

    private NetworkManager m_networkManager = null;
    
    private void Awake()
    {
        m_networkManager = GameObject.FindObjectOfType<NetworkManager>();
    }
    
    public void SubmitLogin()
    {
        if(m_loginUserNameInput.text == "" || m_loginPasswordInput.text == "")
        {
            m_text.text = "Fill in all the fields to continue";
            return;
        }
        m_text.text = "Loading...";

        m_networkManager.CheckUser(m_loginUserNameInput.text, m_loginPasswordInput.text , delegate(Response response)
        {
             m_text.text = response.message;
             
             if(response.message == "Welcome")
             {
                SceneManager.LoadScene("MainMenu");
             }
         });
    }

    public void CerrarJuegoLogin()
    {
        Debug.Log("Salir..");
        Application.Quit();
    }

    public void SubmitRegister()
    {
        if(m_userNameInput.text == "" || m_emailInput.text == "" || m_password.text == "" || m_reEnterPassword.text == "")
        {
            m_text.text = "Fill in all the fields to continue";
            return;
        }

       if(m_password.text == m_reEnterPassword.text)
       {
            m_text.text = "Loading...";

            m_networkManager.CreateUser(m_userNameInput.text , m_emailInput.text, m_password.text , delegate(Response response)
            {
                m_text.text = response.message;
                m_registerUI.SetActive(false);
                m_loginUI.SetActive(true);
            });
       }
       else
       {
            m_text.text = "Passwords are not the same please verify";
       }
    }
    public void ShowLogin()
    {
        m_registerUI.SetActive(false);
        m_loginUI.SetActive(true);
    }
    public void ShowRegister()
    {
        m_registerUI.SetActive(true);
        m_loginUI.SetActive(false);

    }
    public void ContinueOut()
    {
        SceneManager.LoadScene("MainMenu");
    }
}