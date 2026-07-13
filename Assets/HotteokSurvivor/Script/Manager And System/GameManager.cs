using Study.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HotteokSurvivor.Script.Manager_And_System
{
    public class GameManager : SingletonBase<GameManager>
    {
        public Player Player;
        public GameObject Canvas;
        public PoolingSystem PoolingSystem;

        public float CurrentTime;

        private void Start()
        {
            DontDestroyOnLoad(Canvas);
        }

        private void Update()
        {
            if(SceneManager.GetActiveScene().name=="Game Scene")
            {
                CurrentTime += Time.deltaTime;
            }

            if (CurrentTime >= 10.0f)
            {
                Canvas.GetComponent<UIManager>().SetPanelActive(UIType.ClearMenu, true);
                Destroy(PoolingSystem.gameObject);
                Time.timeScale = 0;
            }
        }

        public void LevelUpPopUp()
        {
            Canvas.transform.GetChild(3).gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}