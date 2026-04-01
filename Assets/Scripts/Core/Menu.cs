using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
   void Jugar()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
   }
}
