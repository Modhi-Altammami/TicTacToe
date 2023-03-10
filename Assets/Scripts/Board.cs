using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Modhi.ticTacToe
{
    public class Board : MonoBehaviour
    {
        private bool isXTurn;
        private int[,] CellArray = new int[3, 3];
        public static Board instance;
        [SerializeField] private GameObject TextAnimation;
        [SerializeField] private TextMeshProUGUI results;
        [SerializeField] private Sprite AppleX;
        [SerializeField] private Sprite PearO;
        void Awake()
        {
            if (instance == null) // if instance is not initilized then instance is equal to class
                instance = this;
            else
            {
                Destroy(gameObject);
            }

        }
        void Start()
        {
            isXTurn = true;
        }
        public void changeTurns(GameObject buttonObj, Vector2 position)
        {
            if (isXTurn)
            {
                buttonObj.GetComponentInChildren<Image>().sprite = AppleX;
                CellArray[(int)position.x, (int)position.y] = -1;
            }
            else
            {
                buttonObj.GetComponentInChildren<Image>().sprite = PearO;
                CellArray[(int)position.x, (int)position.y] = 1;
            }

            checkWinSCertainCell((int)position.x, (int)position.y);

            isXTurn = !isXTurn;
        }

        void checkWinSCertainCell(int x, int y)
        {
            //Horizontal
            int total = 0;

            for (int i = 0; i < CellArray.GetLength(0); i++)
            {
                total += CellArray[x, i];
                if (CellArray[x, i] == 0)
                {
                    break; 
                }
                if (total == CellArray.GetLength(0) || total == -1 * CellArray.GetLength(0))
                {
                    AnnounceWinner(total);
                    return;
                }

            }

            //Vertical
            total = 0;
            for (int i = 0; i < CellArray.GetLength(0); i++)
            {
                total += CellArray[i, y];
                if (CellArray[i, y] == 0)
                {
                    break; ;
                }
                if (total == CellArray.GetLength(0) || total == -1 * CellArray.GetLength(0))
                {
                    AnnounceWinner(total);
                    return;
                }

            }
            //Diagonal
            total = 0;
            if (x == y)
            {
                for (int j = 0; j < CellArray.GetLength(1); j++)
                {
                    total += CellArray[j, j];
                    if (CellArray[j, j] == 0)
                    {
                        break; 
                    }
                    if (total == CellArray.GetLength(0) || total == -1 * CellArray.GetLength(0))
                    {
                        AnnounceWinner(total);
                        return;

                    }
                }
            }

            //reverse diagonal
            total = 0;
            if (y + x == CellArray.GetLength(0) - 1)
            {
                int count = CellArray.GetLength(1) - 1;
                for (int i = 0; i < CellArray.GetLength(0); i++)
                {
                    total += CellArray[i, count];
                    if (CellArray[i, count] == 0)
                    {
                        break; 
                    }
                    if (total == CellArray.GetLength(0) || total == -1 * CellArray.GetLength(0))
                    {
                        AnnounceWinner(total);
                        return;
                    }
                    count--;
                }
            }


            //No win
            bool isMove = false;
            for (int i = 0; i < CellArray.GetLength(0); i++)
            {
                for (int j = 0; j < CellArray.GetLength(1); j++)
                {
                    if (CellArray[i, j].Equals(0))
                    {
                        isMove = true;
                    }
                }
            }

            if (!isMove)
            {
                AnnounceWinner(0);
                return;
            }
            isMove = false;

        }
        void AnnounceWinner(int total)
        {
            if (total == CellArray.GetLength(0))
            {
                results.text = "Pear wins!";
            }
            else if (total == -1 * CellArray.GetLength(0))
            {
                results.text = "Apple wins!";
            }
            else
            {
                results.text = "Try Again?";
            }
            TextAnimation.SetActive(true);
            LeanTween.scale(TextAnimation, new Vector3(1.3f, 1.3f, 1.3f), 1f).setEase(LeanTweenType.easeOutElastic); ;
            gameObject.SetActive(false);

        }
    }
}
