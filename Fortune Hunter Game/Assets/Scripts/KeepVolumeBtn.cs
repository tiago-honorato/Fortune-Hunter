using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepVolumeBtn : MonoBehaviour
{

    private static KeepVolumeBtn instance;

    void Awake()
    {
        // Verificar se já existe uma instância do AudioController na cena
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Impede que o objeto seja destruído ao trocar de cena
        }
        else
        {
            Destroy(gameObject); // Se já existe um, destrói o novo para evitar duplicação
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
