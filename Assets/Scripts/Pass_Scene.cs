using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pass_Scene : MonoBehaviour
{
    public void ChangeScene(int level)
    {
        SceneManager.LoadScene(level);
    }
}
