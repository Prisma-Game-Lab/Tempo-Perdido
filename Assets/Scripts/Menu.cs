using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject painelMenuInicial;
    public GameObject painelOpcoes;
    public GameObject painelCreditos;

    public void IniciarJogo (int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void BotaoOpcoes () 
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }
    
    public void BotaoOpcoesVoltar () 
    {
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void SairJogo ()
    {
        Application.Quit();
    }
    
    public void BotaoCreditos () 
    {
        painelMenuInicial.SetActive(false);
        painelCreditos.SetActive(true);
    }

    public void BotaoCreditosVoltar () 
    {
        painelMenuInicial.SetActive(true);
        painelCreditos.SetActive(false);
    }

}
